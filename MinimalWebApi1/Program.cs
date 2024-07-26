using Microsoft.EntityFrameworkCore;
using MinimalWebApi1.DbContext;
using MinimalWebApi1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDb"))
);
builder.Services.AddScoped<IStudentService, StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal API V2");
        c.RoutePrefix = string.Empty; // To serve the Swagger UI at the app's root (http://localhost:<port>/)
    });}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
