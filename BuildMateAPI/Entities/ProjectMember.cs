namespace BuildMateAPI.Entities;

public class ProjectMember
{
	public Guid Id { get; set; }
	public Project Project { get; set; } = null!;
	public Guid ProjectId { get; set; }
	public User User { get; set; } = null!;
	public Guid UserId { get; set; }
	public required string Role { get; set; }
	public required DateTime JoinedAt { get; set; }
}
