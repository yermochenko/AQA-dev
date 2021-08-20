using lab_3.Json;
using System;
using System.Text.Json.Serialization;

namespace lab_3.Domain
{
    public class MobilePhone
    {
        public string Model { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OperationSystemType OperationSystemType { get; set; }

        [JsonConverter(typeof(MarketLaunchDateJsonConverter))]
        public DateTime MarketLaunchDate { get; set; }

        [JsonConverter(typeof(PriceJsonConverter))]
        public int Price { get; set; }

        public bool IsAvailable { get; set; }

        [JsonPropertyName("ShopId"), JsonConverter(typeof(ShopJsonConverter))]
        public Shop Shop { get; set; }

        public override string ToString()
        {
            return $"{Model} ({OperationSystemType}) - ${Price}, market launch date {MarketLaunchDate:MM.yyyy}, {(IsAvailable ? "available" : "not available")}, Shop {Shop.Name}";
        }
    }
}
