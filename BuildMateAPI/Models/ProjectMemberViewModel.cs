namespace BuildMateAPI.Models;

public class ProjectMemberViewModel
{
	public Guid Id { get; set; }
	public required string Name { get; set; }
	public required string Email { get; set; }
	public required string Role { get; set; }
	public required DateTime JoinedAt { get; set; }
}
