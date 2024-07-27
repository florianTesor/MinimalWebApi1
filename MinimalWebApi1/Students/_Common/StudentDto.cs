namespace MinimalWebApi1.Students._Common;

public record StudentDto(int Id, string Name,string Lastname,DateTime Birthday, string Email, bool HasSubscribed);
