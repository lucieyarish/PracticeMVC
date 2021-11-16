using Microsoft.AspNetCore.Mvc;
using SpaceTransporter.Models.Entities;
using SpaceTransporter.Services;
using SpaceTransporter.ViewModels;

namespace SpaceTransporter.Controllers
{
    public class HomeController : Controller
    {
        private PlanetService PlanetService { get; }
        private ShipService ShipService { get; }

        public HomeController(PlanetService planetService, ShipService shipService)
        {
            PlanetService = planetService;
            ShipService = shipService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var result = new ShipViewModel()
            {
                Ships = ShipService.FindAll(),
                Planets = ShipService.FindAllWithPlanets()
            };
            return View(result);
        }

        [HttpPost("{id}/edit")]
        public IActionResult HandleDockedUndocked([FromRoute]int id)
        {
            var foundShip = ShipService.EditDockAndUndock(id);
            var result = new ShipViewModel()
            {
                Ship = foundShip,
                Ships = ShipService.FindAll(),
                Planets = ShipService.FindAllWithPlanets()
            };
            return View("Index", result);

        }
        
        [HttpPost("ships")]
        public IActionResult CreateShip(Ship newShip)
        {
            var shipToSave = ShipService.CreateNewShip(newShip);
            var result = new ShipViewModel()
            {
                Ship = shipToSave,
                Ships = ShipService.FindAll(),
                Planets = ShipService.FindAllWithPlanets()
            };
            return View("Index", result);
        }

        // [HttpPost("ships")]
        // public IActionResult CreateShip(Ship newShip)
        // {
        //     Planet foundPlanet = ShipService.FindPlanetByPlanetId(newShip);
        //     int planetId = foundPlanet.Id;
        //     ShipService.CreateNewShip(newShip, planetId);
        //     var result = new ShipViewModel()
        //     {
        //         Ship = newShip,
        //         Ships = ShipService.FindAll(),
        //         Planets = ShipService.FindAllWithPlanets()
        //     };
        //     return View("Index", result);
        // }
        
        [HttpPost("ships/{id}/move")]
        public IActionResult MoveShip([FromQuery] int id)
        {
            var foundShip = ShipService.FindById(id);
            ShipService.CheckIfDocked(id);
            ShipService.ReturnUndocked(id, foundShip);
            var result = new ShipViewModel()
            {
                Ship = foundShip,
                Ships = ShipService.FindAll(),
                Planets = ShipService.FindAllWithPlanets()
            };
            return View("Index", result);
        }

        [HttpDelete("planet/{id}")]
        public IActionResult RemovePlanet([FromRoute] int id)
        {
            PlanetService.DeletePlanet(id);
            return RedirectToAction("Index");
        }

        [HttpGet("ships")]
        public IActionResult ReturnFastestShips([FromQuery] float warpAtLeast)
        {
            var fastestShips = ShipService.ReturnFastest(warpAtLeast);
            var result = new ShipViewModel()
            {
                // Ship = foundShip,
                Ships = fastestShips,
                Planets = ShipService.FindAllWithPlanets()
            };
            return View("Index", result);
        }
        
        
    }
}