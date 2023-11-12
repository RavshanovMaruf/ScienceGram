using Microsoft.AspNetCore.Identity;

namespace ScienceGram.Core.Entities
{
	public class User : IdentityUser<int>
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public DateTime? BirthDate { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
		public string? Country { get; set; }
		public string? Fax { get; set; }
		public DateTime RegistrationDate { get; set; }
		public ICollection<Experience> Experiences { get; set; }
		public ICollection<Education> Educations { get; set; }
		public virtual ICollection<Project> Projects { get; set; }
		public virtual ICollection<Collaboration> Collaborations { get; set; }
		public virtual ICollection<ChatMessage> SenderChatMessages { get; set; }
		public virtual ICollection<ChatMessage> ReceiverChatMessages { get; set; }
	}
}
