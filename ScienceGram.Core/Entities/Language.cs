using ScienceGram.Core.Common;

namespace ScienceGram.Core.Entities
{
	public class Language : BaseAuditableEntity
	{
		public string Name { get; set; }
		public string Code { get; set; }
		public virtual ICollection<ProjectLanguage> ProjectLanguages { get; set; }
	}
}
