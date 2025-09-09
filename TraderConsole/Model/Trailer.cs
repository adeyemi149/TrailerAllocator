using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraderConsole.Model
{
    public class Trailer
    {
        public int MaxLength { get; set; }
        public int MaxWeight { get; set; }
        public List<Car> Cars { get; set; }
    }
}