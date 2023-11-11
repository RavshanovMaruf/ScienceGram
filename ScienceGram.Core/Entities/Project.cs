using ScienceGram.Core.Common;

namespace ScienceGram.Core.Entities
{
	public class Project : BaseAuditableEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Status { get; set; }
		public int ProjectStatusId { get; set; }
		public virtual ProjectStatus ProjectStatus { get; set; }
		public int? CategoryId { get; set; }
		public virtual Category? Category { get; set; }
		public int LeadScientistID { get; set; }
		public virtual User LeadScientist { get; set; }
		public virtual ICollection<Collaboration> Collaborations { get; set; }
	}
}
