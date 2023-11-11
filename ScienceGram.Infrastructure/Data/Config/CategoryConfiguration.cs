using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScienceGram.Core.Entities;

namespace ScienceGram.Infrastructure.Data.Config
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(c => c.Name).HasMaxLength(50).IsRequired(true);
			builder.HasMany(c => c.Children).WithOne(c => c.ParentCategory).IsRequired(false);
		}
	}
}
