using System.Collections.Generic;
using SpaceTransporter.Models.Entities;

namespace SpaceTransporter.ViewModels
{
    public class PlanetViewModel
    {
        public Planet Planet { get; set; }
        public List<Planet> Planets { get; set; }
    }
}