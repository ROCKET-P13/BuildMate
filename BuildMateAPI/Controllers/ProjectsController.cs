using Microsoft.AspNetCore.Mvc;

namespace BuildMateAPI.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
	[HttpGet("{projectId:int}")]
	public async Task<ActionResult> GetById([FromRoute] int projectId)
	{
		return Ok(new { ProjectId = projectId });
	}
}
