using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyProject.Models;
using System.Data.Entity;
using VidlyProject.ViewModels;

namespace VidlyProject.Controllers
{
  public class MoviesController : Controller
  {

    private ApplicationDbContext _context;

    public MoviesController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }

    //Get: Movies
    public ActionResult Index()
    {
      var model = _context.Movies.Include(g => g.Genre).ToList();

      return View(model);
    }

    public ActionResult New()
    {
      var genres = _context.Genres.ToList();
      var viewModel = new MovieFormViewModel
      {
        Genres = genres
      };

      return View("MovieForm", viewModel);
    }

    [HttpPost]
    public ActionResult Save(Movie movie)
    {
      if (movie.Id == 0)
      {
        movie.DateAdded = DateTime.Today;
        _context.Movies.Add(movie);
      }
      else
      {
        var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
        movieInDb.Name = movie.Name;
        movieInDb.GenreId = movie.GenreId;
        movieInDb.ReleaseDate = movie.ReleaseDate;
        movieInDb.NumberInStock = movie.NumberInStock;
      }

      _context.SaveChanges();

      return RedirectToAction("Index", "Movies");
    }

    public ActionResult Edit(int id)
    {
      var movieToEdit = _context.Movies.SingleOrDefault(m => m.Id == id);
      if (movieToEdit == null)
        return HttpNotFound();

      var viewModel = new MovieFormViewModel
      {
        Movie = movieToEdit,
        Genres = _context.Genres
      };

      return View("MovieForm", viewModel);
    }

    public ActionResult Details(int id)
    {
      var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);

      return View(movie);
    }  
  }
}