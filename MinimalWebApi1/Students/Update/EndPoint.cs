using MinimalWebApi1.Core.Services;
using MinimalWebApi1.Students._Common;

namespace MinimalWebApi1.Students.Update;

public  static class EndPoint
{
    
    public static WebApplication MapUpdateStudent(this WebApplication app)
    {
        app.MapPut(Constants.STUDENT_ROUTE_PATTERN+ "/Update", HandleAsync);
            
        return app;
    }

    private  static async Task<Response> HandleAsync(IStudentService studentService, Request request)
    {
            var result = await studentService.UpdateStudentAsync(request.StudentDto.ToStudent());
            var response = new Response(result?.ToStudentDto());
            return response;
    }
    
}