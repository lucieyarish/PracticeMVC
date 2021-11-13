using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using RateMyMentor.Models.Entities;

namespace RateMyMentor.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Mentor> Mentors { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}