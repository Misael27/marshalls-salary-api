using MarshallsSalary.Core.DTO;
using MarshallsSalary.Core.Models;
using MarshallsSalary.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarshallsSalary.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Populate 100 Employees with the last 6 months of salary records for each employee.
        /// </summary>
        /// <response code="200">Ok</response>

        // POST: api/Employee/5
        [HttpPost("DataDummy")]
        public IActionResult DataDummy()
        {
            _employeeService.PostCreateDataDummy();
            return Ok();
        }

        /// <summary>
        /// Gets a employee with their salaries by name and surname.
        /// </summary>
        /// <param name ="filterDTO"></param>
        /// <returns>A employee</returns>
        /// <response code="200">If the employee were found</response>
        /// <response code="400">If the employee were not found</response> 

        // GET: api/Employee/Name
        [HttpGet("Name")]
        public IActionResult GetEmployeeByName([FromQuery] FilterNameDTO filterDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var employee = _employeeService.GetEmployeeByName(filterDTO);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        /// <summary>
        /// Create or Update a employee with their salaries.
        /// </summary>
        /// <param name ="employeeDTO"></param>
        /// <returns>A employee</returns>
        /// <response code="200">Returns the updated item</response>
        /// <response code="400">If the item is null</response> 

        // POST: api/Employee
        [HttpPost]
        public IActionResult PostEmployeeSalary([FromBody] EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
            {
               return BadRequest();
            }
            _employeeService.PostEmployeeSalary(employeeDTO);
            return Ok();
        }

        /// <summary>
        /// Gets employee list
        /// </summary>
        
        // GET: api/Employee
        [HttpGet]
        public IActionResult GetEmployeeList([FromQuery] FilterOptionDTO filterDTO)
        {
            var employees = _employeeService.GetEmployeeList(filterDTO);
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        /// <summary>
        /// return salary average of a employee
        /// </summary>
        
        // GET: api/Employee/Average
        [HttpGet("Average")]
        public IActionResult GetSalaryAverage([FromQuery] FilterCodeDTO filterDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var employee = _employeeService.getSalaryAverage(filterDTO);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

    }
}
