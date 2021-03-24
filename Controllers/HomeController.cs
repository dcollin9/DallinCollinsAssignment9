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

        public IActionResult Index()
        {
            return View();
        }

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

        //post method for the EnterMovies view
        [HttpPost]
        public IActionResult EnterMovies(EnterMoviesModel enterMovies)
        {

            context.Filmes.Update(enterMovies);
            context.SaveChanges();
            //ensures data is valid before putting it into the temporary storage
            //if (ModelState.IsValid)
            //{
            // TempMovieStorage.AddApplication(enterMovies); //calls the AddApplication method in the TempMovieStorage class and passes it the instance of the object
            // Response.Redirect("DisplayMovies");
            //}

            //loads the EnterMovies view and passes it the instanse of enterMovies
            return View("DisplayMovies", new FilmListViewModel
            {
                Filmes = _repository.Filmes
            .Where(f => f.title != "Independence Day")
            });
        }

        //grabs movie information from the database and displays it
        public IActionResult DisplayMovies()
        {

            //passes the Movies list
            return View(new FilmListViewModel
            {
                Filmes = _repository.Filmes
            .Where(f => f.title != "Independence Day")
            });
        }

        [HttpGet]
        public IActionResult EditRow(EnterMoviesModel movie)
        {
            return View("EditMovie", movie);
        }

        //edits the movie
        [HttpPost]
        public IActionResult EditMovies(EnterMoviesModel movie)
        {
            context.Filmes.Update(movie);
            context.SaveChanges();

            return View("DisplayMovies", new FilmListViewModel
            {
                Filmes = _repository.Filmes
            .Where(f => f.title != "Independence Day")
            });
        }

        [HttpPost]
        public IActionResult DeleteRow(EnterMoviesModel movie)
        {

            context.Filmes.Remove(movie);
            context.SaveChanges();

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
