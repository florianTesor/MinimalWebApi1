namespace Domain.Models;

//Domain: Contains domain entities and value objects.

public class Student
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public string Lastname { get; set; } = string.Empty;

    public DateTime Birthdate { get; set; }

    public string Email { get; set; } = string.Empty;

    public bool HasSubscribed { get; set; }

    public Student()
    {
        
    }

    public Student(int id , string name, string lastname, DateTime birthdate, string email, bool hasSubscribed)
    {
        Id = id;
        Name = name;
        Lastname = lastname;
        Birthdate = birthdate;
        Email = email;
        HasSubscribed = hasSubscribed;

    }
    //Navigations properties
    // public ICollection<Grade> Grades { get; set; } = new List<Grade>();

}