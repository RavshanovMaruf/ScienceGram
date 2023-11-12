using ScienceGram.Core.Common;

namespace ScienceGram.Core.Entities
{
	public class ProjectSkill : BaseAuditableEntity
	{
		public int ProjectId { get; set; }
		public virtual Project Project { get; set; }
		public string SkillName { get; set; }
	}
}
