using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Probamos.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Probamos.Controllers
{

    [ApiController]
    [Route("api/turnos")]
    public class TurnosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TurnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var turnos = _context.Turnos.ToList();

            return Ok(turnos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Turnos turno)
        {
            if (turno == null)
            {
                return BadRequest();
            }

            _context.Turnos.Add(turno);
            _context.SaveChanges();

            return CreatedAtAction("Get", new { id = turno.IdTurno }, turno);
        }
    }
}
