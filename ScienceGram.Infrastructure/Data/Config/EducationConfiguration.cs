using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScienceGram.Core.Entities;

namespace ScienceGram.Infrastructure.Data.Config
{
	public class EducationConfiguration : IEntityTypeConfiguration<Education>
	{
		public void Configure(EntityTypeBuilder<Education> builder)
		{
			builder.HasOne(w => w.User)
				.WithMany(u => u.Educations)
				.IsRequired(true);

			builder.Property(w => w.Institution).HasMaxLength(100).IsRequired(true);
			builder.Property(w => w.Degree).HasMaxLength(100).IsRequired(true);
			builder.Property(w => w.FieldOfStudy).HasMaxLength(100).IsRequired(true);
			builder.Property(w => w.StartYear).IsRequired(true);
			builder.Property(w => w.EndYear).IsRequired(true);
		}
	}
}
