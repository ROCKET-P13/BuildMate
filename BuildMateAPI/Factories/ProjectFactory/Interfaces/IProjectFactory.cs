using BuildMateAPI.Entities;
using BuildMateAPI.Factories.ProjectFactory.DTOs;

namespace BuildMateAPI.Factories.ProjectFactory.Interfaces;

public interface IProjectFactory
{
	Project FromDto(ProjectFactoryDTO dto);
}
