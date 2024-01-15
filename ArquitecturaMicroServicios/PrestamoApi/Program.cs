using PrestamoInfrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BDConfiguracion>(
    builder.Configuration.GetSection("cadenaConexion"));
builder.Services.AddSingleton<PrestamobdContext>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
