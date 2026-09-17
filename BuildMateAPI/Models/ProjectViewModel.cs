namespace BuildMateAPI.Models;

public class ProjectViewModel
{
	public Guid Id { get; set; }
	public Guid OwnerId { get; set; }
	public required string Name { get; set; }
	public required string Description { get; set; }
	public required string Stage { get; set; }
	public required string Type { get; set; }
	public required string Commitment { get; set; }
	public string? RepositoryUrl { get; set; }
	public required DateTime CreatedAt { get; set; }
	public List<ProjectMemberViewModel> Members { get; set; } = [];
}
