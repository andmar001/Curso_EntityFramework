using Microsoft.EntityFrameworkCore;
using project_ef.Models;

namespace project_ef
{
    public class TareasContext:DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public TareasContext(DbContextOptions<TareasContext> options) : base(options){ }
    }
}