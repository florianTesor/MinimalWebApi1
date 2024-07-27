using MinimalWebApi1.Core.Services;
using MinimalWebApi1.Students._Common;

namespace MinimalWebApi1.Students.List;

public  static class EndPoint
{
    public static WebApplication MapListStudent(this WebApplication app)
    {
        app.MapGet(Constants.STUDENT_ROUTE_PATTERN+ "/Get", HandleAsync);
            
        return app;
    }

    private  static async Task<Response> HandleAsync(IStudentService studentService)
    {
            var students = await studentService.GetAllStudentsAsync();
            var response = new Response(students.ToStudentDtoList());
            return response;
    }
    
}