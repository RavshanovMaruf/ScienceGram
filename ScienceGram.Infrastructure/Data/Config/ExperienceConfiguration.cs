using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScienceGram.Core.Entities;

namespace ScienceGram.Infrastructure.Data.Config
{
	public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
	{
		public void Configure(EntityTypeBuilder<Experience> builder)
		{
			builder.HasOne(w => w.User)
				.WithMany(u => u.Experiences)
				.IsRequired(true);

			builder.Property(w => w.Company).HasMaxLength(100).IsRequired(true);
			builder.Property(w => w.Position).HasMaxLength(100).IsRequired(true);
		}
	}
}
