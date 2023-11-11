using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScienceGram.Core.Entities;

namespace ScienceGram.Infrastructure.Data.Config
{
	public class ProjectStatusConfiguration : IEntityTypeConfiguration<ProjectStatus>
	{
		public void Configure(EntityTypeBuilder<ProjectStatus> builder)
		{
			builder.Property(s => s.Name).HasMaxLength(50).IsRequired(true);
		}
	}
}
