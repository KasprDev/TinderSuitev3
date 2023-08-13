using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class Purchase
    {
        [JsonProperty("product_type")] public string ProductType { get; set; }

        [JsonProperty("purchase_type")] public string PurchaseType { get; set; }

        [JsonProperty("product_id")] public string ProductId { get; set; }

        [JsonProperty("terms")] public int Terms { get; set; }

        [JsonProperty("platform")] public string Platform { get; set; }
    }
}