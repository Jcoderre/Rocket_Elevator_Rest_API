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
    public class BuildingDetailController : ControllerBase
    {
        // Context
        private readonly RocketElevatorsContext _context;

        public BuildingDetailController(RocketElevatorsContext context)
        {
            _context = context;

        }

        // Get full list of addresses                                   
         
        [HttpGet("all")]
        public IEnumerable<BuildingDetail> GetBuildingDetails()
        {
            IQueryable<BuildingDetail> buildingdetails =
            from buildingdetail in _context.BuildingDetails
            select buildingdetail;
            return buildingdetails.ToList();

        }
        
    }
}