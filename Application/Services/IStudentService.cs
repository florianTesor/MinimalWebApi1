using Application.DTOs;
using Domain.Models;

namespace Application.Services;

public interface IStudentService
{
    Task<StudentDto?> GetStudentByIdAsync(int id);
    Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
    Task<StudentDto> AddStudentAsync(StudentDto student);
    Task<bool> UpdateStudentAsync(StudentDto studentDto);
    Task<bool> DeleteStudentAsync(int id);
}