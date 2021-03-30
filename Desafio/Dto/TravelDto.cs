using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Dto
{
    public class TravelDto
    {
        [JsonProperty("rickId")]
        public int RickId { get; set; }

        [JsonProperty("dimensionId")]
        public int DimensionId { get; set; }
    }
}
