namespace BuildMateAPI.Entities;

public class ProjectNeed
{
	public Guid Id { get; set; }
	public Project Project { get; set; } = null!;
	public Guid ProjectId { get; set; }
	public required string Role { get; set; }
	public required string Description { get; set; }
	public bool Required { get; set; }
}
