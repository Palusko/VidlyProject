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

    public ActionResult New()
    {
      var membershipTypes = _context.MembershipTypes.ToList();
      var viewModel = new CustomerFormViewModel
      {
        MembershipTypes = membershipTypes
      };
      return View("CustomerForm", viewModel);
    }

    [HttpPost]
    public ActionResult Save(Customer customer)
    {
      //if customer doesn't exist, add him to db, ortherwise update the record
      if (customer.Id == 0)
        _context.Customers.Add(customer);
      else
      {
        var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

        //TryUpdateModel(customerInDb, "", new string[] { "Name", "Email" }); //default approach. Updates all properties of the object
        //TryUpdateModel(customerInDb, "", new string[] { "Name", "Email"}); //default approach. Updates listed properties Name and Email

        customerInDb.Name = customer.Name;
        customerInDb.Birthday = customer.Birthday;
        customerInDb.MembershipTypeId = customer.MembershipTypeId;
        customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
      }
      
      _context.SaveChanges();

      return RedirectToAction("Index", "Customers");
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

    public ActionResult Edit(int id)
    {
      var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
      if (customer == null)
        return HttpNotFound();

      var viewModel = new CustomerFormViewModel
      {
        Customer = customer,
        MembershipTypes = _context.MembershipTypes.ToList()
      };

      return View("CustomerForm", viewModel); //we are overriding the view, otherwise by default, it would look for Edit view
    }
  }
}