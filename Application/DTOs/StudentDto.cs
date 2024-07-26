namespace Application.DTOs;

public record StudentDto(int Id, string Name, string Lastname,
                    DateTime Birthdate, string Email, bool HasSubscribed );