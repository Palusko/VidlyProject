using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyProject.Models;
using VidlyProject.ViewModels;

namespace VidlyProject.Controllers
{
  public class MoviesController : Controller
  {
    private List<Movie> movies = new List<Movie>
                                {
                                  new Movie { Name = "Shrek", Id = 1},
                                  new Movie { Name = "Matrix", Id = 2 }
                                };

    //Get: Movies
    public ActionResult Index()
    {
      var model = new Movie();
      model.Movies = movies;

      return View(model);
    }

    public ActionResult Details(int id)
    {
      var model = new Movie();
      model.Movies = movies;
      var movie = model.Movies.FirstOrDefault(m => m.Id == id);

      return View(movie);
    }

    // GET: Movies/Random
    public ActionResult Random()
    {
      var movie = new Movie() { Name = "Shrek" };

      var customers = new List<Customer>
      {
        new Customer { Name = "Pavol", Id = 1},
        new Customer { Name = "Daniel", Id = 2 }
      };

      var viewModel = new RandomMovieViewModel
      {
        Movie = movie,
        Customers = customers
      };

      return View(viewModel);
    }    
  }
}