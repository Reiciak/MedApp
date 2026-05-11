namespace Backend.Models;

public class Result : IDModel
{
    public Guid Id { get; set; }
    public required Guid PatientId { get; set; }
    public required string TestName { get; set; }
    public required double ResultValue { get; set; }
    public required string Scale { get; set; }
}