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
    public class AddressController : ControllerBase
    {
        // Context
        private readonly RocketElevatorsContext _context;

        public AddressController(RocketElevatorsContext context)
        {
            _context = context;

        }

        // Get full list of addresses                                   
         
        [HttpGet("all")]
        public IEnumerable<Address> GetAddresses()
        {
            IQueryable<Address> addresses =
            from address in _context.Addresses
            select address;
            return addresses.ToList();

        }
        
    }
}