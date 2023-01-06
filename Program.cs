using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_ef;
using project_ef.Models;

// public IConfiguration Configuration { get;  }
// public Program(IConfiguration configuration)
// {
//     Configuration = configuration;
// }

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

app.Run();