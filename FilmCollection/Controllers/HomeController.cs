using FilmCollection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FilmCollection.Controllers
{
    public class HomeController : Controller
    {
        private MovieSubmissionContext _context;

        public HomeController(MovieSubmissionContext temp)
        {
            _context = temp;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Joel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(Submission response)
        {
            _context.Submissions.Add(response);
            _context.SaveChanges();
            
            return View("Confirmation", response);
        }

        public IActionResult MovieList ()
        {
            var submissions = _context.Submissions
                .OrderBy(x => x.Title).ToList();

            return View(submissions);
        }
    }
}
