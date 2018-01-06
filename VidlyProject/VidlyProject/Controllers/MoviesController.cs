using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyProject.Models;
using System.Data.Entity;

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

    public ActionResult Details(int id)
    {
      var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);

      return View(movie);
    }  
  }
}