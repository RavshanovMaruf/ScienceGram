using ScienceGram.Core.Common;

namespace ScienceGram.Core.Entities
{
	public class ProjectLanguage : BaseAuditableEntity
	{
		public int ProjectId { get; set; }
		public virtual Project Project { get; set; }
		public string Language { get; set; }
	}
}
