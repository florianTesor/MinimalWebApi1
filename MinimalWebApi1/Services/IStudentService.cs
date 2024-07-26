using MinimalWebApi1.DbContext.Models;

namespace MinimalWebApi1.Services;

public interface IStudentService
{
    Task<Student?> GetStudentByIdAsync(int id);
    Task<IEnumerable<Student>> GetAllStudentsAsync();
    Task<bool> AddStudentAsync(Student student);
    Task<bool> UpdateStudentAsync(Student student);
    Task<bool> DeleteStudentAsync(int id);
}