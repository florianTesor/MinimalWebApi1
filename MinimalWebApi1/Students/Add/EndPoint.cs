using MinimalWebApi1.Core.Services;
using MinimalWebApi1.Students._Common;

namespace MinimalWebApi1.Students.Add;

public  static class EndPoint
{
    
    public static WebApplication MapAddStudent(this WebApplication app)
    {
        app.MapPost(Constants.STUDENT_ROUTE_PATTERN+ "/Add", HandleAsync);
            
        return app;
    }

    private  static async Task<Response> HandleAsync(IStudentService studentService, Request request)
    {
            var result = await studentService.AddStudentAsync(request.StudentDto.ToStudent());
            var response = new Response(result.ToStudentDto());
            return response;
    }
    
}