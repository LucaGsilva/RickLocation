using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Desafio.Models.Models
{
    public class Rick
    {   
        
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("dimensionid", NullValueHandling = NullValueHandling.Ignore)]
        public int DimensionId { get; set; }

        [JsonProperty("dimension", NullValueHandling = NullValueHandling.Ignore)]
        public Dimension Dimension { get; set; }

        [JsonProperty("travels", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Travel> Travels { get; set; }

    }
}
