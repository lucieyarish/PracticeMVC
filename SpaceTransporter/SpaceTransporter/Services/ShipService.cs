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

        public Planet FindPlanetByPlanetId(Ship ship)
        {
            return DbContext.Planets.Where(p => p.Id == ship.PlanetId).ToList().FirstOrDefault();
        }
        
        public Ship CreateNewShip(Ship ship)
        {
            // var savedShip = DbContext.Ships.Add(ship).Entity;
            // var foundPlanet = FindPlanetByPlanetId(savedShip);
            // savedShip.Name = ship.Name;
            // savedShip.MaxWarpSpeed = ship.MaxWarpSpeed;
            // savedShip.IsDocked = false;
            // // savedShip.PlanetId = planetId;
            // savedShip.PlanetId = foundPlanet.Id;
            // DbContext.SaveChanges();
            // return savedShip;
            var shipToSave = new Ship()
            {
                Name = ship.Name,
                MaxWarpSpeed = ship.MaxWarpSpeed,
                IsDocked = false,
                PlanetId = ship.PlanetId

            };
            var savedShip = DbContext.Ships.Add(shipToSave).Entity;
            DbContext.SaveChanges();
            return savedShip;
        }

        // public Ship CreateNewShip(Ship ship, int planetId)
        // {
        //     var savedShip = DbContext.Ships.Add(ship).Entity;
        //     savedShip.IsDocked = false;
        //     savedShip.PlanetId = planetId;
        //     // savedShip.PlanetId = FindPlanetByPlanetId(savedShip).Id;
        //     DbContext.SaveChanges();
        //     return savedShip;
        // }

        public Ship EditDockAndUndock(int id)
        {
            var foundShip = FindById(id);
            foundShip.IsDocked = !foundShip.IsDocked;
            DbContext.SaveChanges();
            return FindById(id);
        }

        public bool CheckIfDocked(int id)
        {
            return FindById(id).IsDocked;
        }

        public Ship ReturnUndocked(int id, Ship ship)
        {
            if (!CheckIfDocked(id))
            {
                ship.PlanetId =
            }
        }
    }
}