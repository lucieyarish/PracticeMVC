using System.Collections.Generic;
using SpaceTransporter.Models;
using SpaceTransporter.Models.Entities;

namespace SpaceTransporter.ViewModels
{
    public class ShipViewModel
    {
        public Ship Ship { get; set; }

        public List<Ship> Ships { get; set; }
        public List<Planet> Planets { get; set; }
        public List<FastShip> FastestShips { get; set; }
    }
}