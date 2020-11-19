using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RocketElevatorsAPI.Models;
using RocketElevatorsAPI.Data;

// using Microsoft.EntityFrameworkCore;
// using MySql.Data;
// using MySql.Data.MySqlClient;

namespace RocketElevatorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BuildingController : ControllerBase
    {
        // Context
        private readonly RocketElevatorsContext _context;

        public BuildingController(RocketElevatorsContext context)
        {
            _context = context;

        }

        // Get full list of buildings                                  
        // https://localhost:3000/api/building/all
        // GET: api/building/all           
        [HttpGet("all")]
        public IEnumerable<Building> GetBuildings()
        {
            IQueryable<Building> buildings  =
            from building in _context.Buildings
            select building;
            return buildings.ToList();

        }

        // Retrieve list of Buildings requiring intervention 
        // https://localhost:3000/api/building/intervention
        // GET: api/building/intervention             
        [HttpGet("intervention")]
        public IEnumerable<Building> GetBuildingsIntervention() 
        {
            IQueryable<Building> buildings = 
            from building in _context.Buildings
            join battery in _context.Batteries on (building.Id).ToString() equals battery.Building_Id
            join column in _context.Columns on battery.Id equals column.Battery_Id
            join elevator in _context.Elevators on column.Id equals elevator.Column_Id
            where elevator.Status.ToLower() == "intervention" || column.Status.ToLower() == "intervention" || column.Status.ToLower() == "intervention"
            select building;
            return buildings.ToList().Distinct();
            
        }



    }
}