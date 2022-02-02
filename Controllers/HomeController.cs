using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext movieContext { get; set; }

        //Constructor
        public HomeController(MovieContext someName)
        {
            movieContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        // add a new movie page
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = movieContext.Categories.ToList();
            return View();
        }

        // once the movie is entered, add it to the database and display the confirmation page
        [HttpPost]
        public IActionResult AddMovie(Movie m)
        {
            if (ModelState.IsValid)
            {
            movieContext.Add(m);
            movieContext.SaveChanges();
            return View("Confirmation", m);
            }
            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();
                return View();
            }
        }
        
        // show the podcast page 
        public IActionResult Podcast()
        {
            return View();
        }

        public IActionResult MovieList ()
        {
            var movies = movieContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();
            return View(movies);
        }

        //Edit Record
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            var movie = movieContext.Movies.Single(x => x.MovieId == movieid);

            return View("AddMovie", movie);
        }

        //After editing a record, return to the movielist page
        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            movieContext.Update(m);
            movieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }

        // Delete record 
        [HttpGet]
        public IActionResult Delete ( int movieid)
        {
            var movie = movieContext.Movies.Single(x => x.MovieId == movieid);
            return View(movie);
        }

        // after deleting a record, return to the movie list page
        [HttpPost]
        public IActionResult Delete (Movie m)
        {
            movieContext.Movies.Remove(m);
            movieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
