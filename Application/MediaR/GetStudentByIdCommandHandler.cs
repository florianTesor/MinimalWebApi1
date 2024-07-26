using Application.DTOs;
using Application.Services;
using MediatR;

namespace Application.MediaR;

public class GetStudentByIdCommandHandler : IRequestHandler<GetStudentByIdCommand, StudentDto?>
{
    private readonly IStudentService _studentService;

    public GetStudentByIdCommandHandler(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<StudentDto?> Handle(GetStudentByIdCommand request, CancellationToken cancellationToken)
    {
        return await _studentService.GetStudentByIdAsync(request.Id);
    }
}