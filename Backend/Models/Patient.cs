namespace Backend.Models;

public class Patient : IDModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
}