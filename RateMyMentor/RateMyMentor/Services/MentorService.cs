using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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

        public List<string> ViewMentors(string className)
        {
            var reallyMentors = new List<string>();
            var tiptopMentors = new List<string>();
            var seadogMentors = new List<string>();
            var robotoMentors = new List<string>();
            
            switch (className)
            {
                case "really":
                    foreach (var mentor in DbContext.Mentors.ToList())
                    {
                        if (mentor.Class == "Really")
                        {
                            reallyMentors.Add(mentor.Name);
                        }
                    }
                    return reallyMentors;
                case "tiptop":
                    foreach (var mentor in DbContext.Mentors.ToList())
                    {
                        if (mentor.Class == "Tiptop")
                        {
                            tiptopMentors.Add(mentor.Name);
                        }
                    }
                    return tiptopMentors;
                case "seadog":
                    foreach (var mentor in DbContext.Mentors.ToList())
                    {
                        if (mentor.Class == "Seadog")
                        {
                            seadogMentors.Add(mentor.Name);
                        }
                    }
                    return seadogMentors;
                default:
                    foreach (var mentor in DbContext.Mentors.ToList())
                    {
                        if (mentor.Class == "Roboto")
                        {
                            robotoMentors.Add(mentor.Name);
                        }
                    }
                    return robotoMentors;
            }
        }
    }
}