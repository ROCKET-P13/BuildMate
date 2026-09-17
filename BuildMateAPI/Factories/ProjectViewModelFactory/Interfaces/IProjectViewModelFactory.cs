using BuildMateAPI.Entities;
using BuildMateAPI.Models;

namespace BuildMateAPI.Factories.ProjectViewModelFactory.Interfaces;

public interface IProjectViewModelFactory
{
	ProjectViewModel FromProject(Project project);
}