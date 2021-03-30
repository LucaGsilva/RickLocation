using Newtonsoft.Json;
using System;

namespace Desafio.Models.Models
{
    public class Travel
    {

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("rickId", NullValueHandling = NullValueHandling.Ignore)]
        public int RickId { get; set; }

        [JsonProperty("dimensionId", NullValueHandling = NullValueHandling.Ignore)]
        public int DimensionId { get; set; }

        [JsonProperty("datetravel", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DateTravel { get; set; }

        [JsonIgnore]
        public Rick Rick { get; set; }

        [JsonProperty("dimension", NullValueHandling = NullValueHandling.Ignore)]
        public Dimension Dimension { get; set; }



    }
}
