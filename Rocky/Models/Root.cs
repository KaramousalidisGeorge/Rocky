using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Models
{
    public class Root
    {
        [JsonProperty("$schema")]
        public string Schema { get; set; }
        public string eventName { get; set; }
       [Key]
        public string surveyId { get; set; }
        public long surveyVersion { get; set; }
        public string name { get; set; }
        public string publishType { get; set; }
        public IList<Question> questions { get; set; }
    }
}
