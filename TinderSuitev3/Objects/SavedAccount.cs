using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderSuitev3.Objects
{
    class SavedAccount
    {
        public string Name { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUsed { get; set; }
        public string XAuthToken { get; set; }
    }
}
