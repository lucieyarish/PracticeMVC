using SpaceTransporter.Persistence;

namespace SpaceTransporter.Services
{
    public class PlanetService
    {
        private ApplicationDbContext DbContext { get; }

        public PlanetService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}