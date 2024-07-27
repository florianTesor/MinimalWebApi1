using MinimalWebApi1.Core.Models;

namespace MinimalWebApi1.Core.Services;

public interface IStudentService
{
    Task<Student?> GetStudentByIdAsync(int id);
    Task<IEnumerable<Student>> GetAllStudentsAsync();
    Task<Student> AddStudentAsync(Student student);
    Task<Student?> UpdateStudentAsync(Student student);
    Task<bool> DeleteStudentAsync(int id);
}