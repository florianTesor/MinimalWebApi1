using Microsoft.EntityFrameworkCore;
using MinimalWebApi1.DbContext;
using MinimalWebApi1.DbContext.Models;

namespace MinimalWebApi1.Services;

public class StudentService : IStudentService
{
    private readonly SchoolContext _context;

    public StudentService(SchoolContext context)
    {
        _context = context;
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        return await _context.Students.FindAsync(id);
    }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<bool> AddStudentAsync(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateStudentAsync(Student student)
    {
        var studentToUpdate = await _context.Students.FindAsync(student.Id);
        if (studentToUpdate == null) return false;

        studentToUpdate.Name = student.Name;
        studentToUpdate.Lastname = student.Lastname;
        studentToUpdate.Birthdate = student.Birthdate;
        studentToUpdate.Email = student.Email;
        studentToUpdate.HasSubscribed = student.HasSubscribed;

        _context.Update(studentToUpdate);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student is null) return false;
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return true;
    }
}