using Application.DTOs;
using Application.Services;
using MediatR;

namespace Application.MediaR;


public class GetAllStudentsCommandHandler : IRequestHandler<GetAllStudentsCommand, IEnumerable<StudentDto>>
{
    private readonly IStudentService _studentService;

    public GetAllStudentsCommandHandler(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<IEnumerable<StudentDto>> Handle(GetAllStudentsCommand request, CancellationToken cancellationToken)
    {
        return await _studentService.GetAllStudentsAsync();
    }
}