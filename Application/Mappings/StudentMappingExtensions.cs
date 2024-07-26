using Application.DTOs;
using Domain.Models;

namespace Application.Mappings;

    public static class StudentMappingExtensions
    {
        public static List<StudentDto> ToStudentDtoList(this IEnumerable<Student> students)
        {
            return students.Select(student =>student.ToStudentDto()).ToList();
        }
        public static StudentDto ToStudentDto(this Student student)
        {
            return new StudentDto(student.Id,
                student.Name,
                student.Lastname,
                student.Birthdate,
                student.Email,
                student.HasSubscribed);
        }
        public static Student  ToStudent(this StudentDto student)
        {
            return new Student(student.Id,
                student.Name,
                student.Lastname,
                student.Birthdate,
                student.Email,
                student.HasSubscribed);
        }
    }
