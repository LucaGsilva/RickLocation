
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Desafio
{
    public class ApplicationResult
    {
        public ApplicationResult()
        {
            Code = 200;
            Messages = new List<String>();
        }


        [JsonProperty ("code") ]
        public int Code { get; set; }

        [JsonProperty("messages")]
        public IList<string> Messages { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
    }
}
