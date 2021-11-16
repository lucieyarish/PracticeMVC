namespace SpaceTransporter.Models
{
    public class FastShip
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Location { get; set; }
        public float MaximumWarp { get; set; }
        public bool IsDocked { get; set; }
    }
}