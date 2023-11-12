using ScienceGram.Core.Common;

namespace ScienceGram.Core.Entities
{
	public class Education : BaseAuditableEntity
	{
		public int UserId { get; set; }
		public virtual User User { get; set; }
		public string Institution { get; set; }
		public string Degree { get; set; }
		public string FieldOfStudy { get; set; }
		public int StartYear { get; set; }
		public int EndYear { get; set; }
	}
}
