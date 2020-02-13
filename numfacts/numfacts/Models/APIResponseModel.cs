using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numfacts.Models
{
    // This model holds the response that is sent back to us from the API.
    public class APIResponseModel
    {
        [DeserializeAs(Name = "text")]
        public string Text { get; set; }

        [DeserializeAs(Name = "number")]
        public int Number { get; set; }

        [DeserializeAs(Name = "found")]
        public bool Found { get; set; }

        [DeserializeAs(Name = "type")]
        public string Type { get; set; }
    }
}
