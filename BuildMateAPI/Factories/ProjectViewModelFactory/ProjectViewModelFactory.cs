using BuildMateAPI.Entities;
using BuildMateAPI.Factories.ProjectViewModelFactory.Interfaces;
using BuildMateAPI.Models;

namespace BuildMateAPI.Factories.ProjectViewModelFactory;

public class ProjectViewModelFactory : IProjectViewModelFactory
{
	public ProjectViewModel FromProject(Project project)
	{
		return new ProjectViewModel
		{
			Id = project.Id,
			OwnerId = project.Owner.Id,
			Name = project.Name,
			Description = project.Description,
			Stage = project.Stage,
			Type = project.Type,
			Commitment = project.Commitment,
			RepositoryUrl = project.RepositoryUrl,
			CreatedAt = project.CreatedAt,
			Members =
			[
				.. project.Members.Select(member => new ProjectMemberViewModel
				{
					Id = member.Id,
					Name = $"{member.User.FirstName} ${member.User.LastName}",
					Email = member.User.Email,
					Role = member.Role,
					JoinedAt = member.JoinedAt,
				}),
			],
		};
	}
}
