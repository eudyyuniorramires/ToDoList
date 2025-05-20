using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Tarea> tareas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

       

    }
}
