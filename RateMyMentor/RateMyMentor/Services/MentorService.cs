using System.Collections.Generic;
using System.Linq;
using RateMyMentor.Models;
using RateMyMentor.Models.Entities;
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

        public List<Mentor> FindAll()
        {
            return DbContext.Mentors.ToList();
        }

        public Mentor FindById(long id)
        {
            var foundMentor =
                FindAll()
                    .Where(m => m.Id == id)
                    .ToList()
                    .FirstOrDefault();
            return foundMentor;
        }

        public Mentor CreateMentor(Mentor mentor)
        {
            var savedMentor = DbContext.Mentors.Add(mentor).Entity;
            DbContext.SaveChanges();
            return savedMentor;
        }

        public List<string> ViewReallyMentors(string className)
        {
            var reallyMentors = new List<Mentor>();
            var mentorNames = new List<string>();
            foreach (var mentor in DbContext.Mentors.ToList())
            {
                if (mentor.Class == "really")
                {
                    reallyMentors.Add(mentor);
                }
            }
            foreach (var mentor in reallyMentors)
            {
                mentorNames.Add(mentor.Name);
            }
            return mentorNames;
        }
    }
}