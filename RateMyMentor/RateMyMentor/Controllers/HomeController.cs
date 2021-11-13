using Microsoft.AspNetCore.Mvc;
using RateMyMentor.Models.Entities;
using RateMyMentor.Services;
using RateMyMentor.ViewModels;

namespace RateMyMentor.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private MentorService MentorService { get; }
        public HomeController(MentorService service)
        {
            MentorService = service;
        }

        [HttpGet("")]
        public IActionResult ListAll()
        {
            var result = new MentorViewModel()
            {
                Mentors = MentorService.FindAll()
            };
            return View("Index", result);
        }

        [HttpGet("mentor/{id:long}")]
        public IActionResult GetMentor([FromQuery] long id)
        {
            var foundMentor = MentorService.FindById(id);
            var mentor = new MentorViewModel()
            {
                Mentor = foundMentor
            };
            return View("MentorDetail", mentor);
        }
        
        [HttpPost("mentor")]
        public IActionResult SaveMentor(Mentor mentor)
        {
            MentorService.CreateMentor(mentor);
            return RedirectToAction("ListAll");
        }

       
    }
}