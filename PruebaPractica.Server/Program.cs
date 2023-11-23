using Microsoft.EntityFrameworkCore;
using PruebaPractica.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Configurar conexion Bd

builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
            opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));

builder.Services.AddCors(opciones =>
{
    opciones.AddPolicy("nuevo", app =>
    {
        app.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("nuevo");
app.UseAuthorization();

app.MapControllers();

app.Run();
