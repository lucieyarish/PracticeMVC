using System.Collections.Generic;
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
            var result = new IndexViewModel()
            {
                Mentors = MentorService.FindAll()
            };
            return View("Index", result);
        }

        [HttpGet("mentor/{id}")]
        public IActionResult GetMentor([FromRoute] long id)
        {
            
            var foundMentor = MentorService.FindById(id);
            var mentor = new MentorViewModel()
            {
                MentorDetail = foundMentor
            };
            if (foundMentor is null)
            {
                return View("ErrorPage");
            }
            else
            {
                return View("MentorDetail", mentor);
            }
        }
        
        [HttpPost("mentor")]
        public IActionResult SaveMentor(Mentor mentor)
        {
            MentorService.CreateMentor(mentor);
            return RedirectToAction("ListAll");
        }

        [HttpGet("api/mentors/{className}")]
        public IActionResult GetClassMentors([FromRoute] string className)
        {
            // if (MentorService.CheckIfClassExists(className))
            // {
            //     return BadRequest(new {error = "Bad request!"});
            // }
            
            var allMentors = MentorService.ViewMentors(className);
            if(allMentors.Count == 0)
            {
                return NotFound(new {error = "There aren't any mentors in this class!"});
            }
            return Ok(new {Name = allMentors});
        }

        // [HttpPut("api/mentors/{id}")]
        // public IActionResult UpdateMentor([FromRoute] long id)
        // {
        //     
        // }

        [HttpDelete("api/mentors/{id}")]
        public IActionResult DeleteMentor([FromRoute] long id)
        {
            var foundMentor = MentorService.FindById(id);
            if (foundMentor is null)
            {
                return NotFound(new {error = "There's no mentor assigned to this ID!"});
            }
            MentorService.RemoveMentor(id);
            // return RedirectToAction("ListAll");
            return NoContent();
        }
    }
}