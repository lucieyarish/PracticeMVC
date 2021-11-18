using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}