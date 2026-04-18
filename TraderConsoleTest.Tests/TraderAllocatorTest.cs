using System.Collections.Generic;
using Xunit;
using TraderConsole.Model;
using TraderConsole.Service;

namespace TraderConsoleTest.Tests
{
    public class TraderAllocatorTest
    {
        private readonly TrailerAllocator _allocator = new TrailerAllocator();

        [Fact]
        public void CumulativeWeightExceedsMax_ShouldSpillToNewTrailer()
        {
            // Two cars each weighing 15 — combined 30 exceeds maxW=20, so must split across two trailers
            var cars = new List<Car>
            {
                new Car { Length = 5, Weight = 15 },
                new Car { Length = 5, Weight = 15 }
            };

            var trailers = _allocator.AllocateCarsToTrailers(cars, maxL: 25, maxW: 20);

            Assert.Equal(2, trailers.Count);
            Assert.Single(trailers[0].Cars);
            Assert.Single(trailers[1].Cars);
        }

        [Fact]
        public void CumulativeLengthExceedsMax_ShouldSpillToNewTrailer()
        {
            var cars = new List<Car>
            {
                new Car { Length = 20, Weight = 5 },
                new Car { Length = 10, Weight = 5 }
            };

            var trailers = _allocator.AllocateCarsToTrailers(cars, maxL: 25, maxW: 20);

            Assert.Equal(2, trailers.Count);
        }

        [Fact]
        public void CarsFitWithinCumulativeLimits_ShouldShareTrailer()
        {
            var cars = new List<Car>
            {
                new Car { Length = 10, Weight = 8 },
                new Car { Length = 10, Weight = 8 }
            };

            var trailers = _allocator.AllocateCarsToTrailers(cars, maxL: 25, maxW: 20);

            Assert.Single(trailers);
            Assert.Equal(2, trailers[0].Cars.Count);
        }
    }
}