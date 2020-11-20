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
    public class InterventionController : ControllerBase
    {
        // Context
        private readonly RocketElevatorsContext _context;

        public InterventionController(RocketElevatorsContext context)
        {
            _context = context;

        }

        // Get full list of interventions                                    
         
        [HttpGet("all")]
        public IEnumerable<Intervention> GetInterventions()
        {
            IQueryable<Intervention> interventions =
            from intervention in _context.Interventions
            select intervention;
            return interventions.ToList();

        }



        // Retriving Status of All the interventions: pending             
        // https://localhost:5000/api/intervention/pending
        // GET: api/intervention/inpending         

        [HttpGet("pending")]
        public IEnumerable<Intervention> GetpendingInterventions()
        {
            IQueryable<Intervention> interventions = 
            from intervention in _context.Interventions
            where intervention.Status.ToLower() != "complete" // Gets Interventions with "Pending" status
            select intervention;
            return interventions.ToList();
        }



        // Change status of specific intervention
        // http://localhost:5000/api/intervention/{id}
        // PUT api/interventions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterventionStart(ulong id, [FromBody] Intervention intervention)
        {
            if (id != intervention.Id)
            {
                return BadRequest();
            }

            _context.Entry(intervention).State = EntityState.Modified;

            // Columns that we don't want to change
            _context.Entry(intervention).Property(p => p.Id).IsModified                     = false;
            _context.Entry(intervention).Property(p => p.Result).IsModified                 = false;
            _context.Entry(intervention).Property(p => p.Report).IsModified                 = false;
            _context.Entry(intervention).Property(p => p.Status).IsModified                 = false;
            _context.Entry(intervention).Property(p => p.Elevator_Id).IsModified            = false;
            _context.Entry(intervention).Property(p => p.Author).IsModified                 = false;
            _context.Entry(intervention).Property(p => p.Customer_id).IsModified            = false;
            _context.Entry(intervention).Property(p => p.Building_id).IsModified            = false;
            _context.Entry(intervention).Property(p => p.Column_id).IsModified              = false;
            _context.Entry(intervention).Property(p => p.Employee_id).IsModified            = false;
            _context.Entry(intervention).Property(p => p.Battery_id).IsModified             = false;
            _context.Entry(intervention).Property(p => p.CreatedAt).IsModified              = false;
            _context.Entry(intervention).Property(p => p.UpdatedAt).IsModified              = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (id != intervention.Id)
                {
                    // Resource doesn't exist.
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
           
            var dbIntervention = _context.Interventions.FirstOrDefault(intervention => intervention.Id == id);          
            return  Content("Status of the Intervention with ID #" + intervention.Id + ": changed Start of intervention to " + intervention.InterventionStart); 
        }
        
    }
}