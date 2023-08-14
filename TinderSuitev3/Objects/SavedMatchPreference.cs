using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderSuitev3.Objects
{
    public class SavedMatchPreference
    {
        public string[] Ethnicities { get; set; }
        public string[] ZodiacSigns { get; set; }
        public string[] Interests { get; set; }
        public string[] Intent { get; set; }
        public bool EnableIncomeCheck { get; set; }
        public long MinimumIncome { get; set; }

        public bool NoPets { get; set; }
        public bool NoKids { get; set; }
        public bool NoSmokers { get; set; }
        public bool NoPoly { get; set; }
        public bool NoTrans { get; set; }
        public bool NoCis { get; set; }
    }
}
