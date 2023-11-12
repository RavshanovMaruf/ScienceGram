using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScienceGram.Core.Entities;

namespace ScienceGram.Infrastructure.Data.Config
{
	public class ProjectSkillConfiguration : IEntityTypeConfiguration<ProjectSkill>
	{
		public void Configure(EntityTypeBuilder<ProjectSkill> builder)
		{
			builder.Property(w => w.SkillName).HasMaxLength(100).IsRequired(true);
		}
	}
}
