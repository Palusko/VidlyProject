using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyProject.Models;

namespace VidlyProject.Controllers
{
  public class MoviesController : Controller
  {
    // GET: Movies/Random
    public ActionResult Random()
    {
      var movie = new Movie() { Name = "Shrek" };
      return View(movie);
    }
  }
}