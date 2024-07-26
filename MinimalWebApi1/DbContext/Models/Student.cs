namespace MinimalWebApi1.DbContext.Models;

public class Student
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public string Lastname { get; set; } = string.Empty;

    public DateTime Birthdate { get; set; }

    public string Email { get; set; } = string.Empty;

    public bool HasSubscribed { get; set; }
    
    //Navigations properties
    // public ICollection<Grade> Grades { get; set; } = new List<Grade>();

}