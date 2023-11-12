using AutoMapper;
using ScienceGram.Application.Features.Projects.Commands.Create;
using ScienceGram.Core.Entities;

namespace ScienceGram.Application.Features.Projects.Profiles
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Project, CreatedProjectResponse>();
		}
	}
}
