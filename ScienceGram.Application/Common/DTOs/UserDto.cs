namespace ScienceGram.Application.Common.DTOs
{
	public class UserDto
	{
		public int Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Email { get; set; }
		public string? Fax { get; set; }
		public DateTime? BirthDate { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
		public string? Country { get; set; }
	}
}
