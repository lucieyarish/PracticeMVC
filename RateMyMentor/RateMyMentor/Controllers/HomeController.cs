using Microsoft.AspNetCore.Mvc;
using RateMyMentor.Services;

namespace RateMyMentor.Controllers
{
    public class HomeController : Controller
    {
        private MentorService MentorService { get; }
        public HomeController(MentorService service)
        {
            MentorService = service;
        }
        
    }
}