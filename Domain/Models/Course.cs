using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

[Serializable]
public class Course
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name can only contain letters.")]

    public string Name { get; set; } = string.Empty;

    public int TeacherId { get; set; }
    
    //Navigation Properties
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}