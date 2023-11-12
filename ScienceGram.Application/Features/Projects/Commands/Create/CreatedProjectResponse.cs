using ScienceGram.Application.Common.DTOs;

namespace ScienceGram.Application.Features.Projects.Commands.Create
{
	public class CreatedProjectResponse
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Field { get; set; }
		public ICollection<ProjectSkillDto> ProjectSkillNames { get; set; }
		public ICollection<ProjectLanguageDto> ProjectLanguages { get; set; }
	}
}
