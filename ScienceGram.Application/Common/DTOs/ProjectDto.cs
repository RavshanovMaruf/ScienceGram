namespace ScienceGram.Application.Common.DTOs
{
	public class ProjectDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int? UserId { get; set; }
		public UserDto User { get; set; }
		public int? CategoryId { get; set; }
		public CategoryDto Category { get; set; }
		public int? ProjectStatusId { get; set; }
		public virtual ProjectStatusDto ProjectStatus { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
	}
}
