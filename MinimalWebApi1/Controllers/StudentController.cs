using Application.DTOs;
using Application.MediaR;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MinimalWebApi1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudents()
        {
            var query = new GetAllStudentsCommand();
            var students = await _mediator.Send(query);
            return Ok(students);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentById(int id)
        {
            var query = new GetStudentByIdCommand(id);
            var student = await _mediator.Send(query);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost ("Add")]
        public async Task<ActionResult<StudentDto>> AddStudent(StudentDto studentDto)
        {
            var command = new AddStudentCommand(studentDto);
            var student = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateStudent(StudentDto studentDto)
        {
            var command = new UpdateStudentCommand(studentDto);
            var result = await _mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var command = new DeleteStudentCommand(id);
            var result = await _mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
