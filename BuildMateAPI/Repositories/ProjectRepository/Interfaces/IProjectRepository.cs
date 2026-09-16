using BuildMateAPI.Entities;

namespace BuildMateAPI.Repositories.ProjectRepository.Interfaces;

public interface IProjectRepository
{
	Task<Project?> FindById(Guid id);
	Task<Project?> FindByName(string name);
	Task<Project?> FindByOwnerId(Guid ownerId);
	void Upsert(Project project);
}
