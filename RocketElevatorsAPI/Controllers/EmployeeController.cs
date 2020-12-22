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
    public class EmployeeController : ControllerBase
    {

        // Context
        private readonly RocketElevatorsContext _context;

        public EmployeeController(RocketElevatorsContext context)
        {
            _context = context;

        }

        // Get full list of Employyes                                   
        // https://localhost:5000/api/employee/all
        // GET: api/employee/all           
        [HttpGet("all")]
        public IEnumerable<Employee> GetEmployees()
        {
            IQueryable<Employee> employees =
            from employee in _context.Employees
            select employee;
            return employees.ToList();

        }

        // https://localhost:5000/api/employee/find/{email}
        // GET: api/employee/find/{email}
        [HttpGet("find/{email}")]        
        public ActionResult<Employee> GetEmployeeEmail(string email) 
        {
            var decodedEmail = System.Web.HttpUtility.UrlDecode(email);            
            //Console.WriteLine(decodedEmail);            
            var employeeEmail = _context.Employees            
            .Where(e => e.employeeEmail == decodedEmail);            
            //.FirstOrDefaultAsync();            
            if (employeeEmail == null) {                
                return NotFound();            
            }            
            return Ok(employeeEmail);        
        }


    }
}