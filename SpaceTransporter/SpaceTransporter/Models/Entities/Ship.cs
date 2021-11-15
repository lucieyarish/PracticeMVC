namespace SpaceTransporter.Models.Entities
{
    public class Ship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float MaxWarpSpeed { get; set; }
        public string CurrentLocation { get; set; }
        public bool IsDocked { get; set; }
        public Planet Planet { get; set; }
        public int PlanetId { get; set; }
    }
}