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
				.HasForeignKey(w => w.LeadScientistID)
				.IsRequired(true)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(l => l.Category)
				.WithMany(c => c.Projects)
				.HasForeignKey(l => l.CategoryId)
				.IsRequired(false);

			builder.HasOne(l => l.ProjectStatus)
				.WithMany(ls => ls.Projects)
				.HasForeignKey(l => l.ProjectStatusId)
				.IsRequired(true);

			builder.Property(w => w.Title).HasMaxLength(100).IsRequired(true);
			builder.Property(l => l.Description).HasMaxLength(500).IsRequired(false);
			builder.Property(l => l.StartDate).IsRequired(true);
			builder.Property(l => l.EndDate).IsRequired(true);
		}
	}
}