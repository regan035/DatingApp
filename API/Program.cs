using API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// add dbcontext class
builder.Services.AddDbContext<DataContext>(opt=>{
  opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// add cors service to accept request from client
builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder=>builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
