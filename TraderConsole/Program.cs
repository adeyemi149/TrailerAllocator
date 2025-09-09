using TraderConsole.Model;
using TraderConsole.Service;


Car car1 = new Car { Length = 10, Weight = 5 };
Car car2 = new Car { Length = 15, Weight = 10 };
Car car3 = new Car { Length = 5, Weight = 3 };

TrailerAllocator allocator = new TrailerAllocator();
var trailers = allocator.AllocateCarsToTrailers(new List<Car> { car1, car2, car3 });

Console.WriteLine($"Number of trailers used: {trailers.Count}");