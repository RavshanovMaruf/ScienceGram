using ScienceGram.Core.Common;

namespace ScienceGram.Core.Entities
{
	public class Category : BaseAuditableEntity
	{
		public string Name { get; set; }
		public int? ParentCategoryId { get; set; }
		public virtual Category ParentCategory { get; set; }
		public virtual ICollection<Category> Children { get; set; }
		public virtual ICollection<Project> Projects { get; set; }
	}
}
