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
    public class QuoteController : ControllerBase
    {
        // Context
        private readonly RocketElevatorsContext _context;

        public QuoteController(RocketElevatorsContext context)
        {
            _context = context;

        }

        // Get full list of quotes                                    
        // https://localhost:5000/api/quote/all
        // GET: api/quote/all           
        [HttpGet("all")]
        public IEnumerable<Quote> GetQuotes()
        {
            IQueryable<Quote> quotes =
            from quote in _context.Quotes
            select quote;
            return quotes.ToList();

        }
        
    }
}