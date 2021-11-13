using RateMyMentor.Persistence;

namespace RateMyMentor.Services
{
    public class MentorService
    {
        private ApplicationDbContext DbContext { get; set; }
        
        public MentorService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}