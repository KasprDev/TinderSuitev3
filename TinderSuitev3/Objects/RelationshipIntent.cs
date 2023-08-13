using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class RelationshipIntent
    {
        [JsonProperty("body_text")]
        public string BodyText { get; set; }
    }
}
