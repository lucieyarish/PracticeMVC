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

        // public bool DockOrUndock(int id)
        // {
        //     var shipToUndock = FindById(id);
        //     if (shipToUndock.IsDocked)
        //     {
        //         return shipToUndock.IsDocked == true;
        //     }
        //     return shipToUndock.IsDocked;
        // }
    }
}