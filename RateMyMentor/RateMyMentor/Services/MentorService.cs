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
        
        

        // public MentorName FindByClassName(string className)
        // {
        //     var foundMentor = FindAll()
        //         .Where(m => m.Class.ToLower() == className)
        //         .ToList()
        //         .FirstOrDefault();
        //     return foundMentor;
        // }

        public Mentor CreateMentor(Mentor mentor)
        {
            var savedMentor = DbContext.Mentors.Add(mentor).Entity;
            DbContext.SaveChanges();
            return savedMentor;
        }

        public bool CheckIfClassExists(string className)
        {
            var allClasses = new List<string>()
            {
                "really",
                "tiptop",
                "seadog",
                "roboto"
            };
            foreach (var item in allClasses)
            {
                if (item.Contains(className))
                {
                    return true;
                }
            }
            return false;
        }
        
        public List<MentorName> FindAllMentorNames(string className)
        {
            var foundMentors = FindAll()
                .Where(m => m.Class.ToLower() == className)
                .ToList();
            var mentorNames = new List<MentorName>();
            foreach (var item in foundMentors)
            {
                mentorNames.Add(new MentorName()
                {
                    Name = item.Name
                });
            }
            return mentorNames;
        }

        public List<MentorName> ViewMentors(string className)
        {
            var allMentors = new List<MentorName>();
            allMentors = FindAllMentorNames(className);

            // switch (className)
            // {
            //     case "really":
            //         foreach (var mentor in DbContext.Mentors.ToList())
            //         {
            //             if (mentor.Class == "Really")
            //             {
            //                 allMentors.Add(new MentorName()
            //                 {
            //                     Name = mentor.Name
            //                 });
            //             }
            //         }
            //         return allMentors;
                // case "tiptop":
                //     foreach (var mentor in DbContext.Mentors.ToList())
                //     {
                //         if (mentor.Class == "Tiptop")
                //         {
                //             tiptopMentors.Add(mentor.Name);
                //         }
                //     }
                //     return tiptopMentors;
                // case "seadog":
                //     foreach (var mentor in DbContext.Mentors.ToList())
                //     {
                //         if (mentor.Class == "Seadog")
                //         {
                //             seadogMentors.Add(mentor.Name);
                //         }
                //     }
                //     return seadogMentors;
                // default:
                    // foreach (var mentor in DbContext.Mentors.ToList())
                    // {
                    //     if (mentor.Class == "Roboto")
                    //     {
                    //         robotoMentors.Add(mentor.Name);
                    //     }
                    // }
                    return allMentors;
        }
        
        public void RemoveMentor(long id)
        {
            Mentor foundMentor = FindById(id);
            DbContext.Mentors.Remove(foundMentor);
            DbContext.SaveChanges();
        }
    }
    
}