using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lab28_StarWarsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWarsApiPractice.Models;

namespace StarWarsApiPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SwapiDal SP = new SwapiDal();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Person p = SP.GetPerson("people", 3);
            People people = SP.GetPersonList("https://swapi.dev/api/people/");

            List<Person> peeples = new List<Person>();

            peeples.AddRange(people.Person.ToList());
            while (people.next != null)
            {
                people = SP.GetPersonList(people.next);
                peeples.AddRange(people.Person.ToList());
            }
            return View(peeples);
        }

        public IActionResult Privacy(int id)
        {

            return View();
        }

        public IActionResult PersonSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PersonSearch(int Id)
        {
            Person p = SP.GetPerson("people", Id);
            return View(p);
        }

        public IActionResult StarshipSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StarshipSearch(int Id)
        {
            Starship p = SP.GetStarship("starships", Id);
            return View(p);
        }

        public IActionResult PlanetSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PlanetSearch(int Id)
        {
            Planet p = SP.GetPlanet("planets", Id);
            return View(p);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
