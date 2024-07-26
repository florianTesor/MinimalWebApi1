using Application.DTOs;
using Application.Services;
using MediatR;

namespace Application.MediaR;


public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, StudentDto>
{
    private readonly IStudentService _studentService;

    public AddStudentCommandHandler(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<StudentDto> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        return await _studentService.AddStudentAsync(request.StudentDto);
    }
}