using ScienceGram.Core.Common;

namespace ScienceGram.Core.Entities
{
	public class Project : BaseAuditableEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Field { get; set; }
		public int LeadScientistId { get; set; }
		public virtual User LeadScientist { get; set; }
		public virtual ICollection<Collaboration> Collaborations { get; set; }
	}
}
