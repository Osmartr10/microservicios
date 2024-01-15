using EstudianteInfrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
/* Inyeccion de Dependencia del Contexto*/
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbNombre = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_ROOT_PASSWORD");
var cadenaConexion = $"server={dbHost};port=3306;database={dbNombre};user=root;password={dbPassword}";
builder.Services.AddDbContext<EstudiantebdContext>(options => options.UseMySQL(cadenaConexion));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
