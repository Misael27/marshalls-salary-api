using MarshallsSalary.Core.DTO;
using MarshallsSalary.Core.Models;
using MarshallsSalary.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarshallsSalary.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        /// <summary>
        /// Get all offices.
        /// </summary>
        /// <returns>Offices</returns>
        /// <response code="200">OK</response>
        /// <response code="500">Internal Error</response> 

        // GET: api/Office
        [HttpGet]
        public IActionResult GetAllOffices()
        {
            return Ok(_officeService.GetAll());
        }

    }
}
