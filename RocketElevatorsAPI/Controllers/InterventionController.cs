using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketElevatorsAPI.Models;
using RocketElevatorsAPI.Data;
using System.Globalization;




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
        // http://localhost:5000/api/intervention/all
        // GET: api/intervention/all                                    
        [HttpGet("all")]
        public IEnumerable<Intervention> GetInterventions()
        {
            IQueryable<Intervention> interventions =
            from intervention in _context.Interventions
            select intervention;
            return interventions.ToList();

        }
        // REQUIREMENT #1
        // Retriving Status of All the interventions: pending             
        // https://localhost:5000/api/intervention/ispending
        // GET: api/intervention/inpending         

        [HttpGet("ispending")]
        public IEnumerable<Intervention> GetIspendingInterventions()
        {
            IQueryable<Intervention> interventions = 
            from intervention in _context.Interventions
            where intervention.InterventionStart == null            // Gets all intervention with no date
            where intervention.Status.ToLower() != "interrupted"    // Gets Interventions with "Pending" status
            where intervention.Status.ToLower() != "complete"
            where intervention.Status.ToLower() != "incomplete"
            where intervention.Status.ToLower() != null
            select intervention;
            return interventions.ToList();
        }




        // Change status of specific intervention
        // http://localhost:5000/api/intervention/{id}
        // PUT api/interventions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChangeIntervention(ulong id, [FromBody] Intervention intervention)
        {
            if (id != intervention.id)
            {
                return BadRequest();
            }

            _context.Entry(intervention).State = EntityState.Modified;

            // Columns that we don't want to change
            _context.Entry(intervention).Property(p => p.id).IsModified                     = false;
            _context.Entry(intervention).Property(p => p.Result).IsModified                 = false;
            _context.Entry(intervention).Property(p => p.Report).IsModified                 = false;
            _context.Entry(intervention).Property(p => p.Elevator_id).IsModified            = false;
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
                if (id != intervention.id)
                {
                    // Resource doesn't exist.
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
           
            var dbIntervention = _context.Interventions.FirstOrDefault(intervention => intervention.id == id);
            dbIntervention.Status = "inProgress";
            //dbIntervention.InterventionStart = 
            //dbIntervention.InterventionStop = 

            return  Content("Status of the Intervention with ID #" + intervention.id + " as changed. The intervention start at :" + intervention.InterventionStart + " and end at: " + intervention.InterventionStop  + ". Is status is now: " + intervention.Status); 
        }
        
    }
}