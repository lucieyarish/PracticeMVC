using System.Collections.Generic;
using SpaceTransporter.Models.Entities;

namespace SpaceTransporter.ViewModels
{
    public class ShipViewModel
    {
        public Ship Ship { get; set; }

        public List<Ship> Ships { get; set; }
    }
}