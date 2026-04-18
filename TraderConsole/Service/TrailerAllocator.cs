using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TraderConsole.Model;

namespace TraderConsole.Service
{
    public class TrailerAllocator
    {
        public List<Trailer> AllocateCarsToTrailers(List<Car> cars, int maxL = 25, int maxW = 20)
        {
            List<Trailer> trailers = new List<Trailer>();

            Trailer currentTrailer = new Trailer { MaxLength = maxL, MaxWeight = maxW, Cars = new List<Car>() };
            int usedLength = 0;
            int usedWeight = 0;

            foreach (var car in cars)
            {
                if (usedLength + car.Length <= currentTrailer.MaxLength && usedWeight + car.Weight <= currentTrailer.MaxWeight)
                {
                    currentTrailer.Cars.Add(car);
                    usedLength += car.Length;
                    usedWeight += car.Weight;
                }
                else
                {
                    trailers.Add(currentTrailer);
                    currentTrailer = new Trailer { MaxLength = maxL, MaxWeight = maxW, Cars = new List<Car>() };
                    usedLength = car.Length;
                    usedWeight = car.Weight;
                    currentTrailer.Cars.Add(car);
                }
            }

            trailers.Add(currentTrailer);

            return trailers;
        }
    }
}