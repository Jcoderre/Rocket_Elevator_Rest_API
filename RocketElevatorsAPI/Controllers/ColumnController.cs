using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketElevatorsAPI.Models;
using RocketElevatorsAPI.Data;

namespace RocketElevatorsAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ColumnController : ControllerBase
    {

        // Context
        private readonly RocketElevatorsContext _context;
         
        public ColumnController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // Get full list of columns                          
        // http://localhost:5000/api/columns/all
        // GET: api/columns/all           
        [HttpGet("all")]
        public IEnumerable<Column> GetColumns()
        {
            IQueryable<Column> columns =
            from column in _context.Columns
            select column;
            return columns.ToList();

        }

        // Get status of specific battery
        // http://localhost:5000/api/batteries/{id}
        // GET: api/columns/{id}
        [HttpGet("{id}")]
        public string GetStatus(ulong id)
        {
            var columns = _context.Columns.Where(column => column.Id == id).ToList();
            return columns[0].Status;
        }


        // Change status of specific column
        // http://localhost:5000/api/columns/{id}
        // PUT api/columns/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(ulong id, [FromBody] Column column)
        {
            if (id != column.Id)
            {
                return BadRequest();
            }

            
            _context.Entry(column).State = EntityState.Modified;

            // Columns that we don't want to change
            _context.Entry(column).Property(p => p.Id).IsModified            = false;
            _context.Entry(column).Property(p => p.Battery_Id).IsModified    = false;
            _context.Entry(column).Property(p => p.Customer_Id).IsModified   = false;
            _context.Entry(column).Property(p => p.BuildingType).IsModified  = false;
            _context.Entry(column).Property(p => p.NumFloors).IsModified     = false;
            _context.Entry(column).Property(p => p.Information).IsModified   = false;
            _context.Entry(column).Property(p => p.Notes).IsModified         = false;
            _context.Entry(column).Property(p => p.CreatedAt).IsModified     = false;
            _context.Entry(column).Property(p => p.UpdatedAt).IsModified     = false;
            

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (id != column.Id)
                {
                    // Resource doesn't exist.
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var dbColumn = _context.Columns.FirstOrDefault(column => column.Id == id);
            return Content("Status of Column with ID #" + dbColumn.Id + ": changed status to " + dbColumn.Status);
        }
    }
}