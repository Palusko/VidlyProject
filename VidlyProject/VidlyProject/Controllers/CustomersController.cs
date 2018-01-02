using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyProject.Models;
using System.Data.Entity;

namespace VidlyProject.Controllers
{
  public class CustomersController : Controller
  {
    private ApplicationDbContext _context;

    public CustomersController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }

    // GET: Customers
    public ActionResult Index()
    {
      //need to use Include for eager loading, to load customers and membership type into model (and model to view)
      var customers = _context.Customers.Include(c => c.MembershipType).ToList(); //without ToList, the query does not execute yet (differed). Adding ToList executes it

      return View(customers);
    }

    //Customers/Details/Id
    public ActionResult Details(int id)
    {
      var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id); //SingleOrDefault executes the query (it won't be differed)

      if (customer == null)
        return HttpNotFound();

      return View(customer);
    }
  }
}