using ScienceGram.Core.Common;

namespace ScienceGram.Core.Entities
{
	public class Experience : BaseAuditableEntity
	{
		public int UserId { get; set; }
		public virtual User User { get; set; }
		public string Company { get; set; }
		public string Position { get; set; }
	}
}
