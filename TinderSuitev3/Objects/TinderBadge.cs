using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class TinderBadge
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
