using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Sample.Services;
using Sample.Repositories;
using Sample.Domains;
using System;
using System.Collections.Generic;

namespace SampleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly DBContext _context;

        public EmployeeController(DBContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("saveemployee")]
        public async Task<ActionResult> Save(Employee newEmployee)
        {
            try
            {
                EmployeeService employeeService = new EmployeeService(_context);

                employeeService.Save(newEmployee);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("getallemployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            try
            {
                var employees = _context.Employees;
                if (employees == null)
                {
                    return NotFound();
                }

                return employees;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
