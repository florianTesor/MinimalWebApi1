using Microsoft.EntityFrameworkCore;
using MinimalWebApi1.Core.DbContext;
using MinimalWebApi1.Core.Services;
using MinimalWebApi1.Students.Add;
using MinimalWebApi1.Students.Delete;
using MinimalWebApi1.Students.GetById;
using MinimalWebApi1.Students.List;
using MinimalWebApi1.Students.Update;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Use the full name of the type as the schema ID
    // Because we have same file name in different folders, this option is mandatory for correct schema
    options.CustomSchemaIds(type => type.FullName); 
});

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
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal API V1");
        c.RoutePrefix = string.Empty; // To serve the Swagger UI at the app's root (http://localhost:<port>/)
    });}

app.UseHttpsRedirection();

app.MapListStudent()
    .MapGetStudentById()
    .MapAddStudent()
    .MapUpdateStudent()
    .MapDeleteStudent();

app.Run();
