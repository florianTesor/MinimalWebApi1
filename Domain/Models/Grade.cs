namespace Domain.Models;

[Serializable]
public class Grade
{
    public int Id { get; set; }
    public string Observation { get; set; } = string.Empty;
    public double Value { get; set; }
    // Colonne pour la clef etrangère 
    public int StudentId { get; set; }
    // propriété de navigation ef
    public Student? Student { get; set; }
    // Colonne pour la clef etrangère 
    public int CourseId { get; set; }
    // propriété de navigation ef
    public Course? Course { get; set; }
}