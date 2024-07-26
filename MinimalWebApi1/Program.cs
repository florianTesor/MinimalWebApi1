using Microsoft.EntityFrameworkCore;
using MinimalWebApi1.DbContext;
using MinimalWebApi1.DbContext.Models;
using MinimalWebApi1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

var group = app.MapGroup($"api/{builder.Configuration.GetSection("Version").Value}/{nameof(Student)}");

group.MapGet("/Get",
    async (IStudentService studentService) =>
    {
        var students = await studentService.GetAllStudentsAsync();
        return Results.Ok(students);
    }).WithName("GetAllStudents").WithOpenApi();

group.MapGet("/Get/{id}",
    async (IStudentService studentService, int id) =>
    {
        var student = await studentService.GetStudentByIdAsync(id);
        return student is not null ? Results.Ok(student) : Results.NotFound();
    }).WithName("GetStudentById").WithOpenApi();

group.MapPut("/Update",
    async (IStudentService studentService, Student student) =>
    {
        var result = await studentService.UpdateStudentAsync(student);
        return result ? Results.Ok() : Results.NotFound();
    }).WithName("UpdateStudent").WithOpenApi();

group.MapPost("/Add", 
    async (IStudentService studentService, Student student) =>
        await studentService.AddStudentAsync(student)
        ).WithName("AddStudent").WithOpenApi();

group.MapDelete("/Delete/{id}",
    async (IStudentService studentService, int id) =>
        await studentService.DeleteStudentAsync(id)
        ).WithName("DeleteStudent").WithOpenApi();

app.Run();
