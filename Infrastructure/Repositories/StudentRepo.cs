using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StudentRepo : IStudentRepo
{
    private readonly SchoolContext _context;

    public StudentRepo(SchoolContext context)
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

    public async Task<Student> AddStudentAsync(Student studentToAdd)
    {
        var entityEntry = await _context.Students.AddAsync(studentToAdd);
        
        await _context.SaveChangesAsync();
        return entityEntry.Entity;
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