using DallinCollinsAssignment9.Models;
using DallinCollinsAssignment9.Models.ViewModels.FilmListViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsAssignment9.Controllers
{
    public class HomeController : Controller
    {

        private FilmRepository _repository;
        private readonly ILogger<HomeController> _logger;

        public IApplicationBuilder _app;
        private FilmDBContext context { get; set; }

        //constructor for home controller
        public HomeController(ILogger<HomeController> logger, FilmRepository repository, FilmDBContext con)
        {
            _logger = logger;
            _repository = repository;
            context = con;

        }

        //takes user to home page
        public IActionResult Index()
        {
            return View();
        }

        //takes users to the "Podcasts" page
        public IActionResult MyPodcasts()
        {
            return View();
        }

        //get method for the EnterMovies view
        [HttpGet]
        public IActionResult EnterMovies()
        {
            return View();
        }

        //post method for where the users enter a movie
        [HttpPost]
        public IActionResult EnterMovies(EnterMoviesModel enterMovies)
        {

            context.Filmes.Update(enterMovies);
            context.SaveChanges();

            //returns the view and the information from the database, excluding entries with "Independence Day"
            return View("DisplayMovies", new FilmListViewModel
            {
                Filmes = _repository.Filmes
            .Where(f => f.title != "Independence Day")
            });
        }

        //displays all movie information
        public IActionResult DisplayMovies()
        {

            //returns the view and the information from the database, excluding entries with "Independence Day"
            return View(new FilmListViewModel
            {
                Filmes = _repository.Filmes
            .Where(f => f.title != "Independence Day")
            });
        }


        //takes user to the EditMovie page and displays the movie they chose
        [HttpGet]
        public IActionResult EditRow(EnterMoviesModel movie)
        {
            return View("EditMovie", movie);
        }

        //edits the movie and saves changes to the database
        [HttpPost]
        public IActionResult EditMovies(EnterMoviesModel movie)
        {
            context.Filmes.Update(movie);
            context.SaveChanges();

            //returns the view and the information from the database, excluding entries with "Independence Day"
            return View("DisplayMovies", new FilmListViewModel
            {
                Filmes = _repository.Filmes
            .Where(f => f.title != "Independence Day")
            });
        }


        //deletes a record from the database
        [HttpPost]
        public IActionResult DeleteRow(EnterMoviesModel movie)
        {

            context.Filmes.Remove(movie);
            context.SaveChanges();

            //returns the view and the information from the database, excluding entries with "Independence Day"
            return View("DisplayMovies", new FilmListViewModel
            {
                Filmes = _repository.Filmes
            .Where(f => f.title != "Independence Day")
            });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
