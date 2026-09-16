namespace BuildMateAPI.Controllers.Requests;

public class CreateProjectRequest
{
	public required string Name { get; set; }
	public string? Description { get; set; }
	public string? Stage { get; set; }
	public string? Commitment { get; set; }
	public string? RepositoryUrl { get; set; }
}
