using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsApiPractice.Models
{
    public class People
    {
        public int count { get; set; }
        public string next { get; set; }

        public object previous { get; set; }

        [JsonProperty(PropertyName = "results")] // GOOD TO KNOW.
        public Person[] Person { get; set; }
    }
}

