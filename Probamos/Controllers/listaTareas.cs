using Microsoft.AspNetCore.Mvc;
using Probamos.Models;
using System.Collections.Generic;
using System.Linq;

namespace Probamos.Controllers
{

    [ApiController]
    [Route("api/tareas")]
    public class listaTareas : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public listaTareas(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Work")]
        public IActionResult GetWork()
        {
            var tareas = _context.ToDoList
                .Join(
                    _context.categorias, // La tabla a la que quieres unir
                    tarea => tarea.IdCategoria, // La clave foránea en la tabla ToDoList
                    categoria => categoria.IdCategoria, // La clave primaria en la tabla categorias
                    (tarea, categoria) => new
                    {
                        tarea.idTarea,
                        tarea.nombre,
                        tarea.completa,
                        categoria.Categoria // Campo "categoria" de la tabla categorias
                    })
                .Where(result => result.Categoria == "Work") // Filtro para IdCategoria igual a 1
                .ToList();

            return Ok(tareas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ToDoList tarea)
        {
            if (tarea == null)
            {
                return BadRequest();
            }

            _context.ToDoList.Add(tarea);
            _context.SaveChanges();

            return CreatedAtAction("Get", new { id = tarea.idTarea }, tarea);
        }

        [HttpGet("Home")]
        public IActionResult GetHome()
        {
            var tareas = _context.ToDoList
                .Join(
                    _context.categorias, // La tabla a la que quieres unir
                    tarea => tarea.IdCategoria, // La clave foránea en la tabla ToDoList
                    categoria => categoria.IdCategoria, // La clave primaria en la tabla categorias
                    (tarea, categoria) => new
                    {
                        tarea.idTarea,
                        tarea.nombre,
                        tarea.completa,
                        categoria.Categoria // Campo "categoria" de la tabla categorias
                    })
                .Where(result => result.Categoria == "Home") // Filtro para IdCategoria igual a 1
                .ToList();

            return Ok(tareas);
        }
    }
}
