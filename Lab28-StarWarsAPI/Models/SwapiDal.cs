using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using StarWarsApiPractice.Models;

namespace StarWarsApiPractice.Models
{
    public class SwapiDal
    {
        public string GetAPIJson(string endpoint, int Id)
        {
            string url = $"https://swapi.dev/api/{endpoint}/{Id}/";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());
            string output = sr.ReadToEnd();
            return output;
        }

        public string GetAPIJson(string url)
        {
            //string url = $"https://swapi.dev/api/{endpoint}/";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());
            string output = sr.ReadToEnd();
            return output;
        }


        public Person GetPerson(string endpoint, int Id)
        {
            string personData = GetAPIJson(endpoint, Id);
            Person p = JsonConvert.DeserializeObject<Person>(personData);

            return p;

        }

        public People GetPersonList(string url)
        {

            string personData = GetAPIJson(url);
            People p = JsonConvert.DeserializeObject<People>(personData);

            return p;

        }

        public Starship GetStarship(string endpoint, int Id)
        {
            string starshipData = GetAPIJson(endpoint, Id);
            Starship p = JsonConvert.DeserializeObject<Starship>(starshipData);

            return p;

        }

        public Planet GetPlanet(string endpoint, int Id)
        {
            string planetData = GetAPIJson(endpoint, Id);
            Planet p = JsonConvert.DeserializeObject<Planet>(planetData);

            return p;

        }


    }
}
