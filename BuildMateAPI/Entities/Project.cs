namespace BuildMateAPI.Entities;

public class Project
{
	public Guid Id { get; set; }
	public User Owner { get; set; } = null!;
	public Guid OwnerId { get; set; }
	public required string Name { get; set; }
	public required string Description { get; set; }
	public required string Stage { get; set; }
	public required string Type { get; set; }
	public required string Commitment { get; set; }
	public string? RepositoryUrl { get; set; }
	public required DateTime CreatedAt { get; set; }
	public ICollection<ProjectMember> Members { get; private set; } = new List<ProjectMember>();

	public ProjectMember AddMember(ProjectMember member)
	{
		ArgumentNullException.ThrowIfNull(member);
		Members.Add(member);

		return member;
	}

	public void RemoveParticipant(ProjectMember member)
	{
		ArgumentNullException.ThrowIfNull(member);
		if (!Members.Remove(member))
			throw new InvalidOperationException("Participant is not a member of this room.");
	}
}
