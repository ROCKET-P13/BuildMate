namespace BuildMateAPI.Entities;

public class DeveloperProfile
{
	public Guid Id { get; set; }
	public User User { get; set; } = null!;
	public Guid UserId { get; set; }
	public string? Bio { get; set; }
	public string? AvialabilityHours { get; set; }
	public string? ExperienceLevel { get; set; }
	public string? LookingFor { get; set; }
	public string? Timezone { get; set; }
}
