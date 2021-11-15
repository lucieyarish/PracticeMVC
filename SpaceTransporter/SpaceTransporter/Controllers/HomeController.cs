using Microsoft.AspNetCore.Mvc;
using SpaceTransporter.Services;

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
    }
}