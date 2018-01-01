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

    public ActionResult Details(id)
    {

    }


  }
}