using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarshallsSalary.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarshallsSalary.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly IDivisionService _DivisionService;

        public DivisionController(IDivisionService DivisionService)
        {
            _DivisionService = DivisionService;
        }

        /// <summary>
        /// Get all Divisions.
        /// </summary>
        /// <returns>Divisions</returns>
        /// <response code="200">OK</response>
        /// <response code="500">Internal Error</response> 

        // GET: api/Division
        [HttpGet]
        public IActionResult GetAllDivisions()
        {
            return Ok(_DivisionService.GetAll());
        }

    }
}
