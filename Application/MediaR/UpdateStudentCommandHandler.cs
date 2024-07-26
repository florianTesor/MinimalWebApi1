using Application.Services;
using MediatR;

namespace Application.MediaR;


public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
{
    private readonly IStudentService _studentService;

    public UpdateStudentCommandHandler(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        return await _studentService.UpdateStudentAsync(request.StudentDto);
    }
}