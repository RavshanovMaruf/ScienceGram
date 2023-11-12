using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScienceGram.Core.Entities;

namespace ScienceGram.Infrastructure.Data.Config
{
	public class ProjectLanguageConfiguration : IEntityTypeConfiguration<ProjectLanguage>
	{
		public void Configure(EntityTypeBuilder<ProjectLanguage> builder)
		{
			builder.Property(w => w.Language).HasMaxLength(100).IsRequired(true);
		}
	}
}
