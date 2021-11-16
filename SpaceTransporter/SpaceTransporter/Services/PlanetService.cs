using SpaceTransporter.Models.Entities;
using SpaceTransporter.Persistence;
using System.Linq;

namespace SpaceTransporter.Services
{
    public class PlanetService
    {
        private ApplicationDbContext DbContext { get; }

        public PlanetService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Planet FindPlanetById(int id)
        {
            return DbContext.Planets.Where(s => s.Id == id).ToList().FirstOrDefault();
        }
        public void DeletePlanet(int id)
        {
            Planet foundPlanet = FindPlanetById(id);
            DbContext.Planets.Remove(foundPlanet);
            DbContext.SaveChanges();

        }
    }
}