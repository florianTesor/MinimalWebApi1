using Application.DTOs;
using Application.Mappings;
using Infrastructure.Repositories;

namespace Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepo _studentRepo;

    public StudentService(IStudentRepo studentRepo)
    {
        _studentRepo = studentRepo;
    }

    public async Task<StudentDto?> GetStudentByIdAsync(int id)
    {
        var student =  await _studentRepo.GetStudentByIdAsync(id);
        if (student is null) return null;
        return student.ToStudentDto();
    }

    public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
    {
        var students = await _studentRepo.GetAllStudentsAsync();
        return students.ToStudentDtoList();
    }

    public async Task<StudentDto> AddStudentAsync(StudentDto studentDto)
    {
        var student  = await _studentRepo.AddStudentAsync(studentDto.ToStudent());
        return student.ToStudentDto();
    }

    public async Task<bool> UpdateStudentAsync(StudentDto studentDto)
    {
        return await _studentRepo.UpdateStudentAsync(studentDto.ToStudent());
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        var student = await _studentRepo.GetStudentByIdAsync(id);
        if (student is null) return false;
        await _studentRepo.DeleteStudentAsync(id);
        return true;
    }
    
}

