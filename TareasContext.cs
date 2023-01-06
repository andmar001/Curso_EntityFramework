using Microsoft.EntityFrameworkCore;
using project_ef.Models;

namespace project_ef
{
    public class TareasContext:DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public TareasContext(DbContextOptions<TareasContext> options) : base(options){ }

        //Fluent API configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria { CategoriaId = Guid.Parse("0ca5fc9a-a7c4-4505-b9e1-18767c84c190"), Nombre = "Actividades Pendientes", Peso = 20 });
            categoriasInit.Add(new Categoria { CategoriaId = Guid.Parse("0ca5fc9a-a7c4-4505-b9e1-18767c84c191"), Nombre = "Actividades Personales", Peso = 50 });
            categoriasInit.Add(new Categoria { CategoriaId = Guid.Parse("0ca5fc9a-a7c4-4505-b9e1-18767c84c192"), Nombre = "Actividades Laborales", Peso = 90 });


            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                
                categoria.Property(p=>p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p=>p.Decripcion).IsRequired(false);//No es requerido
                categoria.Property(p=>p.Peso);
                //Agregar datos iniciales a la tabla de categoria
                categoria.HasData(categoriasInit);
            });

            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea { TareaId = Guid.Parse("0ca5fc9a-a7c4-4505-b9e1-18767c84cc10"), CategoriaId = Guid.Parse("0ca5fc9a-a7c4-4505-b9e1-18767c84c190"), PrioridadTarea= Prioridad.Media, Titulo = "Pago de Servicios Publicos", FechaCreacion = DateTime.Now });
            tareasInit.Add(new Tarea { TareaId = Guid.Parse("0ca5fc9a-a7c4-4505-b9e1-18767c84cc11"), CategoriaId = Guid.Parse("0ca5fc9a-a7c4-4505-b9e1-18767c84c191"), PrioridadTarea= Prioridad.Baja, Titulo = "Terminar de ver serie de netflix", FechaCreacion = DateTime.Now });
            tareasInit.Add(new Tarea { TareaId = Guid.Parse("0ca5fc9a-a7c4-4505-b9e1-18767c84cc12"), CategoriaId = Guid.Parse("0ca5fc9a-a7c4-4505-b9e1-18767c84c190"), PrioridadTarea= Prioridad.Alta, Titulo = "Terminar la API de producción", FechaCreacion = DateTime.Now });
            

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);
                tarea.HasOne(p=>p.Categoria).WithMany(p=>p.Tareas).HasForeignKey(p=>p.CategoriaId);//Llave foranea
                tarea.Property(p=>p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p=>p.Descripcion).IsRequired(false);//No es requerido
                tarea.Property(p=>p.PrioridadTarea);
                tarea.Property(p=>p.FechaCreacion);
                tarea.Ignore(p=>p.Resumen);//No se guarda en la base de datos ignore
                tarea.Property(p=>p.Tema).IsRequired(false);//No es requerido

                //Agregar datos iniciales a la tabla de tarea
                tarea.HasData(tareasInit);
            });
        }
    }
} 