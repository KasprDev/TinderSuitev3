using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class ReportUser
    {
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("offender_id")]
        public string OffenderId { get; set; }

        [JsonProperty("primary_code")]
        public ReportCode PrimaryCode { get; set; }

        [JsonProperty("reporter_gender")]
        public int Gender { get; set; }

        [JsonProperty("secondary_code")]
        public int SecondaryCode { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("tertiary_code")]
        public int TertiaryCode { get; set; }

        [JsonProperty("what")]
        public ReportType ReportType { get; set; }
    }

    public enum ReportType
    {
        InPerson = 2,
        Bio = 3,
        Photos = 4,
    }

    public enum ReportCode
    {
        FakeProfile = 200,
        SellingSomething = 500,
        Under18 = 300,
        Nudity = 400,
        HatefulAbusive = 600,
        InPersonSexualHarmOrStalking = 700,
        PossibleThreat = 800
    }
}
