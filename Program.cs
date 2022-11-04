using micro2.Context;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

  var connectionString = builder.Services.AddEntityFrameworkMySQL().AddDbContext < ConexionMySQL > (options => {
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
  });

  var connectionString2 = builder.Configuration.GetConnectionString("DefaultConnectionSQLServer");
    builder.Services.AddDbContext<ConexionSQLServer>(options => options.UseSqlServer(connectionString2));

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
