using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScienceGram.Core.Entities;

namespace ScienceGram.Infrastructure.Data.Config
{
	public class ProjectConfiguration : IEntityTypeConfiguration<Project>
	{
		public void Configure(EntityTypeBuilder<Project> builder)
		{
			builder.HasOne(w => w.LeadScientist)
				.WithMany(u => u.Projects)
				.HasForeignKey(w => w.LeadScientistId)
				.IsRequired(true)
				.OnDelete(DeleteBehavior.NoAction);

			builder.Property(w => w.Title).HasMaxLength(100).IsRequired(true);
			builder.Property(l => l.Description).HasMaxLength(500).IsRequired(false);
			builder.Property(l => l.Field).HasMaxLength(100).IsRequired(false);
		}
	}
}