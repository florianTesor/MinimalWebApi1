using Application.DTOs;
using MediatR;

namespace Application.MediaR;

// Contains MediatR commands/queries, service interfaces, DTOs, and business logic implementations.

public record GetStudentByIdCommand(int Id) : IRequest<StudentDto?>;
public record GetAllStudentsCommand : IRequest<IEnumerable<StudentDto>>;
public record AddStudentCommand(StudentDto StudentDto) : IRequest<StudentDto>;
public record UpdateStudentCommand(StudentDto StudentDto) : IRequest<bool>;
public record DeleteStudentCommand(int Id) : IRequest<bool>;


