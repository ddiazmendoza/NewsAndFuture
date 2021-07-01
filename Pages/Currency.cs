using System.Globalization;
using System.Text.Json.Serialization;


namespace NewsAndFuture.Pages
{

    public partial class Currency
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonPropertyName("network")]
        public string Network { get; set; }

        [JsonPropertyName("prices")]
        public Price[] Prices { get; set; }
    }

    public partial class Price
    {
        [JsonPropertyName("price")]
        public string PricePrice { get; set; }

        [JsonPropertyName("price_base")]
        public string PriceBase { get; set; }

        [JsonPropertyName("exchange")]
        public string Exchange { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }
    }
    
}


