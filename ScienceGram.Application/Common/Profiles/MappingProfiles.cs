using AutoMapper;
using ScienceGram.Application.Common.DTOs;
using ScienceGram.Core.Entities;

namespace ScienceGram.Application.Common.Profiles
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<User, UserDto>();
			CreateMap<Project, ProjectDto>();
			CreateMap<ProjectSkill, ProjectSkillDto>();
			CreateMap<ProjectLanguage, ProjectLanguageDto>();
		}
	}
}
