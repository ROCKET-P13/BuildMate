namespace BuildMateAPI.Entities;

public class ProjectInterest
{
	public Guid Id { get; set; }
	public Project Project { get; set; } = null!;
	public Guid ProjectId { get; set; }
	public User User { get; set; } = null!;
	public Guid UserId { get; set; }
	public string? Message { get; set; }
	public required string Status { get; set; }
	public required DateTime CreatedAt { get; set; }
}
