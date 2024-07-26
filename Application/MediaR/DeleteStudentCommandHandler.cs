using Application.Services;
using MediatR;

namespace Application.MediaR;


public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
{
    private readonly IStudentService _studentService;

    public DeleteStudentCommandHandler(IStudentService studentService)
    {
        _studentService = studentService;
    }

    public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        return await _studentService.DeleteStudentAsync(request.Id);
    }
}