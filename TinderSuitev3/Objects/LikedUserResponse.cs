using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class LikedUserResponse
    {
        [JsonProperty("is_super_like")]
        public bool IsSuperLike { get; set; }
    }
}
