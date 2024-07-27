using MinimalWebApi1.Core.Services;
using MinimalWebApi1.Students._Common;

namespace MinimalWebApi1.Students.GetById;

public  static class EndPoint
{
    
    public static WebApplication MapGetStudentById(this WebApplication app)
    {
        app.MapGet(Constants.STUDENT_ROUTE_PATTERN+ "/Get/{id}", HandleAsync);
            
        return app;
    }

    private  static async Task<Response> HandleAsync(IStudentService studentService,int id)
    {
            var result = await studentService.GetStudentByIdAsync(id);
            var response = new Response(result?.ToStudentDto());
            return response;
    }
    
}