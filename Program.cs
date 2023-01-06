using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_ef;
using project_ef.Models;

var builder = WebApplication.CreateBuilder(args);
//Crea la base de datos en memoria
// builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
//Conexion a la base de datos
// builder.Services.AddDbContext<TareasContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("defaultConnection"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Prueba de la base de datos en memoria
app.MapGet("/dbconexion", async([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", async([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas);
});

app.MapGet("/api/categorias", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Categorias);
});

//filtros
//prioridad tarea baja
app.MapGet("api/prioridad",async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Where(p => p.PrioridadTarea == Prioridad.Baja));
});

//Que categoria venga con toda la informacion - relacion  join 
app.MapGet("api/include",async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(p=>p.Categoria).Where(p=>p.PrioridadTarea == Prioridad.Alta));
});

// create
app.MapPost("api/crearTarea", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    // await dbContext.Tareas.AddAsync(tarea);//segunda forma de agregar el registro
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});


app.Run();