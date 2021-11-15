using System.Collections.Generic;

namespace SpaceTransporter.Models.Entities
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DockingMax { get; set; }
        public List<Ship> Ships { get; set; }
    }
}