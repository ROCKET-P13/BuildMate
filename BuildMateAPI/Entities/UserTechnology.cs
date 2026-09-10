namespace BuildMateAPI.Entities;

public class UserTechnology
{
	public Guid Id { get; set; }
	public User User { get; set; } = null!;
	public Guid UserId { get; set; }
	public required string ProficiencyLevel { get; set; }
	public required int YearsOfExperience { get; set; }
}
