using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyProject.Models;

namespace VidlyProject.Controllers
{
  public class CustomersController : Controller
  {
    private List<Customer> customers = new List<Customer>
                                    {
                                      new Customer {Name = "Pavol", Id = 1},
                                      new Customer {Name = "Daniel", Id = 2}
                                    };
    // GET: Customers
    public ActionResult Index()
    {
      var model = new Customer();//Custumer contains list of customers  
      model.Customers = customers;
      return View(model);
    }

    //Customers/Details/Id
    public ActionResult Details(int id)
    {
      var model = new Customer();
      model.Customers = customers;
      var customer = model.Customers.FirstOrDefault(c => c.Id == id);

      return View(customer);
    }
  }
}