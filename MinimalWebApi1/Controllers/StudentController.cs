using Microsoft.AspNetCore.Mvc;
using MinimalWebApi1.DbContext.Models;
using MinimalWebApi1.Services;

namespace MinimalWebApi1.Controllers;

[ApiController] //This attribute indicates that the class is an API controller.
[Route("/api/V2.0/[controller]")]
public class StudentController : ControllerBase // Important To inherit from ControllerBase class
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await _studentService.GetAllStudentsAsync();
        return Ok(students);
    }

    [HttpGet]
    [Route("Get/{id}")]
    public async Task<IActionResult> GetStudentById(int id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        return student is not null ? Ok(student) : NotFound();
    }
    
    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateStudent([FromForm] Student student)
    {
        var result = await _studentService.UpdateStudentAsync(student);
        return result ? Ok(student) : NotFound();
    }
    
    [HttpPost]
    [Route("Add")]
    public async Task<IActionResult> GetAllStudents([FromForm] Student student)
    {
        var result = await _studentService.UpdateStudentAsync(student);
        return result ? Ok(student) : NotFound();
    }
    
    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<IActionResult> GetAllStudents(int id)
    {
        var result = await _studentService.DeleteStudentAsync(id);
        return result ? Ok() : NotFound();
    }
    
}