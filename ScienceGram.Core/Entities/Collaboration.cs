using ScienceGram.Core.Common;

namespace ScienceGram.Core.Entities
{
	public class Collaboration : BaseAuditableEntity
	{
		public int UserId { get; set; }
		public virtual User User { get; set; }
		public int ProjectId { get; set; }
		public virtual Project Project { get; set; }
	}
}