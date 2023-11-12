namespace ScienceGram.Application.Common.DTOs
{
	public class EducationDto
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Institution { get; set; }
		public string Degree { get; set; }
		public string FieldOfStudy { get; set; }
		public int StartYear { get; set; }
		public int EndYear { get; set; }
	}
}
