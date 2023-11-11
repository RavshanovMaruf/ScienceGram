using ScienceGram.Core.Common;

namespace ScienceGram.Core.Entities
{
	public class ProjectStatus : BaseAuditableEntity
	{
		public string Name { get; set; }
		public virtual ICollection<Project> Projects { get; set; }
	}
}
