using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpaceTransporter.Models.Entities;
using SpaceTransporter.Persistence;

namespace SpaceTransporter.Services
{
    public class ShipService
    {
        private ApplicationDbContext DbContext { get; }

        public ShipService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Ship> FindAll()
        {
            return DbContext.Ships.ToList();
        }

        public List<Planet> FindAllWithPlanets()
        {
            return DbContext.Planets.Include(p => p.Ships).ToList();
        }

        public Ship FindById(int id)
        {
            return DbContext.Ships.Where(s => s.Id == id).ToList().FirstOrDefault();
        }

        public Ship EditDockAndUndock(int id)
        {
            var foundShip = FindById(id);
            foundShip.IsDocked = !foundShip.IsDocked;
            DbContext.SaveChanges();
            return FindById(id);
        }
        
    }
}