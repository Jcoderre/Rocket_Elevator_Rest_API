using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RocketElevatorsAPI.Models;
using RocketElevatorsAPI.Data;

namespace RocketElevatorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // Context
        private readonly RocketElevatorsContext _context;

        public CustomerController(RocketElevatorsContext context)
        {
            _context = context;

        }

        // Get full list of customers                                   
        // https://localhost:5000/api/customer/all
        // GET: api/customer/all  
              
        [HttpGet("all")]
        public IEnumerable<Customer> GetCustomers()
        {
            IQueryable<Customer> customers =
            from customer in _context.Customers
            select customer;
            System.Console.WriteLine(customers);
            return customers.ToList();

        }

        // Get status of specific battery
        // http://localhost:5000/api/customers/{id}
        // GET: api/customers/{id}
        [HttpGet("{id}")]
        public string GetStatus(ulong id)
        {
            var customers = _context.Customers.Where(customer => customer.Id == id).ToList();
            return customers[0].CompanyName;
        }
    }
}