using System;
using Newtonsoft.Json;
using Venues.Api.Convertors;

namespace Venues.Api.ViewModels
{
    public class VenueVM
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("capacity")]
        public int Capacity { get; set; }

        [JsonProperty("createdAt")]
        [JsonConverter(typeof(JsonDateTimeConvertor))]
        public DateTime? CreatedAt { get; set; }
    }
}