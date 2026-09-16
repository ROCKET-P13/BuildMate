using BuildMateAPI.Entities;
using BuildMateAPI.Factories.ProjectFactory.DTOs;
using BuildMateAPI.Factories.ProjectFactory.Interfaces;

namespace BuildMateAPI.Factories.ProjectFactory;

public class ProjectFactory : IProjectFactory
{
	public Project FromDto(ProjectFactoryDTO dto)
	{
		return new Project
		{
			Id = dto.Id ?? Guid.NewGuid(),
			OwnerId = dto.OwnerId,
			Name = dto.Name,
			Description = dto.Description,
			Stage = dto.Stage,
			Type = dto.Type,
			Commitment = dto.Commitment,
			RepositoryUrl = dto.RepositoryUrl,
			CreatedAt = dto.CreatedAt ?? DateTime.UtcNow,
		};
	}
}