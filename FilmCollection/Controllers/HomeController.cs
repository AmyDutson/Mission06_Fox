using FilmCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            
            ViewBag.Categories = _context.Categories
                .ToList();

            return View("Form", new Movie());
        }

        [HttpPost]
        public IActionResult Form(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
            
                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .ToList();

                return View(response);
            }
            
        }

        public IActionResult MovieList ()
        {
            var submissions = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title).ToList();

            return View(submissions);
        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            return View("Form", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit (Movie updatedInfo) 
        {
            _context.Update(updatedInfo);
            _context.SaveChanges(); 

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie submission)
        {
            _context.Movies.Remove(submission);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
