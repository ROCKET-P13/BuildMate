using BuildMateAPI.Data;
using BuildMateAPI.Entities;
using BuildMateAPI.Repositories.ProjectRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BuildMateAPI.Repositories.ProjectRepository;

public class ProjectRepository(AppDatabaseContext databaseContext) : IProjectRepository
{
	private readonly AppDatabaseContext _databaseContext = databaseContext;

	public async Task<Project?> FindById(Guid id)
	{
		return await _databaseContext
			.Projects.Where(project => project.Id == id)
			.Include(project => project.Members)
			.FirstOrDefaultAsync();
	}

	public async Task<Project?> FindByName(string name)
	{
		return await _databaseContext
			.Projects.Where(project => project.Name == name)
			.Include(project => project.Members)
			.FirstOrDefaultAsync();
	}

	public async Task<Project?> FindByOwnerId(Guid ownerId)
	{
		return await _databaseContext
			.Projects.Where(project => project.OwnerId == ownerId)
			.Include(project => project.Members)
			.FirstOrDefaultAsync();
	}

	public void Upsert(Project project)
	{
		ArgumentNullException.ThrowIfNull(project);
		_databaseContext.Projects.Add(project);
	}
}
