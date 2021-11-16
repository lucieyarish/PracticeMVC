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

        // [HttpPost("")]
        // public IActionResult DockUndock(int id)
        // {
        //     var result = new ShipViewModel()
        //     {
        //         Ship = ShipService.DockAndUndock(id);
        //     }
        // }
    }
}