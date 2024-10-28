using BISoft.MiPrimeraApp.Aplicacion.Fabrica;
using BISoft.MiPrimeraApp.Aplicacion.Helpers;
using BISoft.MiPrimeraApp.Aplicacion.Request;
using BISoft.MiPrimeraApp.Aplicacion.Response;
using BISoft.MiPrimeraApp.Aplicacion.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyPrimeraApp.Contextos;
using MyPrimeraApp.Entidades;
using MyPrimeraApp.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



// Configurar el contexto de la base de datos
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer("server=.\\SQLExpress;database = Escuela;Encrypt=false; Trusted_connection=true")
);

//builder.Services.AddDbContext<SecurityCtx>(options =>
//    options.UseSqlServer("server=.\\SQLExpress;database = Escuela;Encrypt=false; Trusted_connection=true")
//);

builder.Services.AddScoped<AlumnoService>();
builder.Services.AddScoped<IAlumnoRepository, AlumnoRepository>();

builder.Services.AddScoped<MaestroService>();
builder.Services.AddScoped<IMaestroRepository, MaestroRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//Obtiene los Alumnos
app.MapGet("/api/alumnos", (AlumnoService service) =>
{
   // var service = ServiceFactory.CrearAlumnoService();
    var alumnos = service.ObtenerAlumnos();
    return alumnos;
});
//Obtiene los Maestros
app.MapGet("/api/Maestros", (MaestroService service) => {

    //var service = ServiceFactory.CrearMaestroService();
    var maestros = service.ObtenerMaestro();
    return maestros;
});

app.MapPost("/api/alumnos", (AlumnoService service,ILogger<AlumnoService> logger,[FromBody] CrearAlumno alumnoDto) => 
{
    try
    {
        logger.LogInformation("Crear el alumno {nombre}", alumnoDto.Nombre);
        var alumno = service.CrearAlumno(alumnoDto.Nombre, alumnoDto.Apellido, alumnoDto.Email);

        var result = alumno.ToEntity();

        return Results.Ok(alumno);
    } catch(InvalidOperationException e)
    {

        logger.LogError(e.Message);
       return Results.BadRequest(e.Message);

    } catch (SqlException e)
    {
        logger.LogError(e.Message);
       return Results.Conflict("Conflicto en Repositorio");

    } catch (Exception e)
    {
        logger.LogError(e.Message);
       return Results.StatusCode(500);
    }

});




app.MapPost("/api/Maestros", (MaestroService service, ILogger<MaestroService> logger, CrearMaestro maestroDto) =>
{
    logger.LogInformation("Crear el Maestro {nombre}", maestroDto.Nombre);
    var maestro  = service.CrearMaestro(maestroDto.Nombre, maestroDto.Apellido, maestroDto.Email, maestroDto.Direccion, maestroDto.Telefono);

    var result = maestro.ToDto();

    return maestro;
});


//app.MapPost("/api/Alumnos", (Alumno alumno) => {

//    var service = ServiceFactory.CrearAlumnoService();
//    var resultado = service.CrearAlumno(alumno.Nombre, alumno.Apellido, alumno.Email);


//    return  resultado;
//});

app.MapGet("/api/Alumnos/{Id}", (AlumnoService service, int id) =>
{
    var alumn = service.ObtenerAlumnoPorId(id);
    if (alumn == null)
    {
        return Results.NotFound("El alumno no se encontro");
    }
    return Results.Ok(alumn);
    
});

app.MapGet("/api/Maestros/{Id}", (MaestroService service, int id) =>
{
    var maestro = service.ObtenerMaestroPorId(id);
    if (maestro == null)
    {
        return Results.NotFound("El Maestro no se encontro");
    }
    return Results.Ok(maestro);
    
});


//app.MapPost("/api/Maestros/", (Maestro maestro) =>
//{

//    var service = ServiceFactory.CrearMaestroService();
//var resultado = service.CrearMaestro(maestro.Nombre, maestro.Apellido, maestro.Direccion, maestro.Email, maestro.Telefono);


//return resultado;
//});



app.Run();

