namespace BuildMateAPI.Factories.ProjectFactory.DTOs;

public class ProjectFactoryDTO
{
	public Guid? Id { get; set; } = null;
	public Guid OwnerId { get; set; }
	public required string Name { get; set; }
	public string? Description { get; set; }
	public string? Stage { get; set; }
	public string? Type { get; set; }
	public string? Commitment { get; set; }
	public string? RepositoryUrl { get; set; }
	public DateTime? CreatedAt { get; set; } = null;
}
