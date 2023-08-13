using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderSuitev3.Objects
{
    public class MatchPreferences
    {
        public bool NoKids { get; set; }
        public bool NoSmoking { get; set; }
        public bool NoCats { get; set; }
        public bool NoDogs { get; set; }
        public string[]? Ethnicities { get; set; }
        public string[]? ZodiacSigns { get; set; }
    }
}
