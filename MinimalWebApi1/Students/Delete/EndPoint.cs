using MinimalWebApi1.Core.Services;
using MinimalWebApi1.Students._Common;

namespace MinimalWebApi1.Students.Delete;

public  static class EndPoint
{
    
    public static WebApplication MapDeleteStudent(this WebApplication app)
    {
        app.MapDelete(Constants.STUDENT_ROUTE_PATTERN+ "/Delete/{id}", HandleAsync);
            
        return app;
    }

    private  static async Task<Response> HandleAsync(IStudentService studentService, int id)
    {
            var result = await studentService.DeleteStudentAsync(id);
            var response = new Response(result);
            return response;
    }
    
}