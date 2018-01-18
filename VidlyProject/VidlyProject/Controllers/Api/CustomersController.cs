using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyProject.Dtos;
using VidlyProject.Models;

namespace VidlyProject.Controllers.Api
{
  public class CustomersController : ApiController
  {
    private ApplicationDbContext _context;

    public CustomersController()
    {
      _context = new ApplicationDbContext();
    }

    //GET /api/customers
    public IEnumerable<CustomerDto> GetCustomers()
    {
      return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
    }

    //GET api/customers/1
    public CustomerDto GetCustomer(int id)
    {
      var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

      if (customer == null)
        throw new HttpResponseException(HttpStatusCode.NotFound);

      return Mapper.Map<Customer, CustomerDto>(customer);
    }

    //POST api/customers
    //this creates a resource, and the convention is to get a response 201 (Created). If we just used CustomerDto, it would
    //work, but give 200 status. So we use IHttpActionResult, which gives 201 status
    /*
    [HttpPost]
    public CustomerDto CreateCustomer(CustomerDto customerDto)
    {
      if (!ModelState.IsValid)
        throw new HttpResponseException(HttpStatusCode.BadRequest);

      var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
      _context.Customers.Add(customer);
      _context.SaveChanges();

      customerDto.Id = customer.Id;
      return customerDto;
    }
    */

    //POST api/customers
    //this creates a resource, and the convention is to get a response 201 (Created). If we just used CustomerDto, it would
    //work, but give 200 status. So we use IHttpActionResult, which gives 201 status
    [HttpPost]
    public IHttpActionResult CreateCustomer(CustomerDto customerDto)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
      _context.Customers.Add(customer);
      _context.SaveChanges();

      customerDto.Id = customer.Id;
      return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
    }

    //PUT api/customer/1
    [HttpPut]
    public void UpdateCustomer(int id, CustomerDto customerDto)
    {
      if (!ModelState.IsValid)
        throw new HttpResponseException(HttpStatusCode.BadRequest);

      var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

      if (customerInDb == null)
          throw new HttpResponseException(HttpStatusCode.NotFound);

      Mapper.Map(customerDto, customerInDb);

      /*
      customerInDb.Name = customerDto.Name;
      customerInDb.Birthday = customerDto.Birthday;
      customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
      customerInDb.MembershipTypeId = customerDto.MembershipTypeId;
      */

      _context.SaveChanges();
    }

    //DELETE api/customers/1
    [HttpDelete]
    public void DeleteCustomer(int id)
    {
      var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

      if (customerInDb == null)
        throw new HttpResponseException(HttpStatusCode.NotFound);

      _context.Customers.Remove(customerInDb);
      _context.SaveChanges();
    }
  }
}
