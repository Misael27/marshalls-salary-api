using MarshallsSalary.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarshallsSalary.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _PositionService;

        public PositionController(IPositionService PositionService)
        {
            _PositionService = PositionService;
        }

        /// <summary>
        /// Get all Positions.
        /// </summary>
        /// <returns>Positions</returns>
        /// <response code="200">OK</response>
        /// <response code="500">Internal Error</response> 

        // GET: api/Position
        [HttpGet]
        public IActionResult GetAllPositions()
        {
            return Ok(_PositionService.GetAll());
        }

    }
}
