using System.Collections.Generic;
using RateMyMentor.Models.Entities;

namespace RateMyMentor.ViewModels
{
    public class IndexViewModel
    {
        public List<Mentor> Mentors { get; set; }
        public Mentor Mentor { get; set; }
    }
}