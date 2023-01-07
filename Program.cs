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
    tarea.TareaId = Guid.NewGuid(); //generar un id
    tarea.FechaCreacion = DateTime.Now; //fecha actual
    await dbContext.AddAsync(tarea);
    // await dbContext.Tareas.AddAsync(tarea);//segunda forma de agregar el registro
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

// update
app.MapPut("api/actualizarTarea/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    var tareaActual = await dbContext.Tareas.FindAsync(id);

    if (tareaActual != null)
    {
        // actualizar los datos
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcion = tarea.Descripcion;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }
    return Results.NotFound();//404    
});

// delete
app.MapDelete("api/eliminarTarea/{id}", async ([FromServices] TareasContext dbContext, [FromRoute]Guid id) =>
{
    // bsucar el registro actual
    var tareaActual = await dbContext.Tareas.FindAsync(id);

    if (tareaActual != null)
    {
        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }
    return Results.NotFound();//404
});

app.Run();