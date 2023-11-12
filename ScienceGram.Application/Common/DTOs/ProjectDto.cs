namespace ScienceGram.Application.Common.DTOs
{
	public class ProjectDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Field { get; set; }
		public int? UserId { get; set; }
		public UserDto User { get; set; }
		public virtual ICollection<ProjectSkillDto> ProjectSkillNames { get; set; }
		public virtual ICollection<ProjectLanguageDto> ProjectLanguages { get; set; }
	}
}
