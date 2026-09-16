using BuildMateAPI.Controllers.Requests;
using BuildMateAPI.Data.UnitOfWork.Interfaces;
using BuildMateAPI.Factories.ProjectFactory.DTOs;
using BuildMateAPI.Factories.ProjectFactory.Interfaces;
using BuildMateAPI.Repositories.ProjectRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BuildMateAPI.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController(
	IUnitOfWork unitOfWork,
	IProjectFactory projectFactory,
	IProjectRepository projectRepository
) : ControllerBase
{
	private readonly IUnitOfWork _unitOfWork = unitOfWork;
	private readonly IProjectFactory _projectFactory = projectFactory;
	private readonly IProjectRepository _projectRepository = projectRepository;

	[HttpGet("{projectId:int}")]
	public async Task<ActionResult> GetById([FromRoute] Guid projectId)
	{
		var project = await _projectRepository.FindById(projectId);
		if (project is null)
		{
			return NotFound("Project not found");
		}

		return Ok(project);
	}

	[HttpPost]
	public async Task<ActionResult> Create([FromBody] CreateProjectRequest request)
	{
		var project = _projectFactory.FromDto(
			new ProjectFactoryDTO
			{
				Id = Guid.NewGuid(),
				Name = request.Name,
				Description = request.Description,
				Stage = request.Stage,
				Commitment = request.Commitment,
				RepositoryUrl = request.RepositoryUrl,
				CreatedAt = DateTime.UtcNow,
			}
		);

		_projectRepository.Upsert(project);
		await _unitOfWork.SaveChanges();
		return Ok(project);
	}
}
