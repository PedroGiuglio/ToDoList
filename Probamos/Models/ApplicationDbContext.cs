using Microsoft.EntityFrameworkCore;
using Probamos.Controllers;

namespace Probamos.Models
{

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Turnos> Turnos { get; set; }
        public DbSet<ToDoList> ToDoList { get; set; }
        public DbSet<categorias> categorias { get; set; } 

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
