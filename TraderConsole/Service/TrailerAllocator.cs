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

            foreach (var car in cars) 
            {
                if (car.Length <= currentTrailer.MaxLength && car.Weight <= currentTrailer.MaxWeight)
                {
                    currentTrailer.Cars.Add(car); // Explanation: Add the car to the current trailer if it fits
                }
                else
                {
                    trailers.Add(currentTrailer); // Explanation: Current trailer is full, add it to the list of trailers
                    currentTrailer = new Trailer { MaxLength = maxL, MaxWeight = maxW, Cars = new List<Car>() }; //Explanation: Create a new trailer
                    currentTrailer.Cars.Add(car); // Explanation: Add the car to the new trailer
                }
            }

            trailers.Add(currentTrailer); // Explanation: Add the last trailer if it has any cars

            return trailers;
        }
    }
}