using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketElevatorsAPI.Models;
using RocketElevatorsAPI.Data;

namespace RocketElevatorsAPI.Controllers {

    [Route("api/[controller]")]
    [ApiController]

    public class BatteryController : ControllerBase
    {

        // Context 
        private readonly RocketElevatorsContext _context;

        public BatteryController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // Get full list of batteries                                  
        // http://localhost:5000/api/battery/all
        // GET: api/battery/all           
        [HttpGet("all")]
        public IEnumerable<Battery> GetBatteries()
        {
            IQueryable<Battery> batteries =
            from battery in _context.Batteries
            select battery;
            return batteries.ToList();

        }

        // Get status of specific battery
        // http://localhost:5000/api/batteries/{id}
        // GET: api/batteries/{id}
        [HttpGet("{id}")]
        public string GetStatus(ulong id)
        {
            var batteries = _context.Batteries.Where(battery => battery.Id == id).ToList();
            return batteries[0].Status;
        }

        // Change status of specific battery
        // http://localhost:5000/api/batteries/{id}
        // PUT api/batteries/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(ulong id, [FromBody] Battery battery)
        {
            if (id != battery.Id)
            {
                return BadRequest();
            }

            _context.Entry(battery).State = EntityState.Modified;

            // Columns that we don't want to change
            _context.Entry(battery).Property(p => p.Id).IsModified                    = false;
            _context.Entry(battery).Property(p => p.Building_Id).IsModified           = false;
            _context.Entry(battery).Property(p => p.Employee_Id).IsModified           = false;
            _context.Entry(battery).Property(p => p.Customer_Id).IsModified           = false;
            _context.Entry(battery).Property(p => p.CommissioningDate).IsModified     = false;
            _context.Entry(battery).Property(p => p.LastInspectionDate).IsModified    = false;
            _context.Entry(battery).Property(p => p.OperationsCertificate).IsModified = false;
            _context.Entry(battery).Property(p => p.Information).IsModified           = false;
            _context.Entry(battery).Property(p => p.Notes).IsModified                 = false;
            _context.Entry(battery).Property(p => p.CreatedAt).IsModified             = false;
            _context.Entry(battery).Property(p => p.UpdatedAt).IsModified             = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (id != battery.Id)
                {
                    // Resource doesn't exist.
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var dbBattery = _context.Batteries.FirstOrDefault(battery => battery.Id == id);
            return  Content("Status of Battery with ID #" + dbBattery.Id + ": changed status to " + dbBattery.Status);  
        }


    }

}