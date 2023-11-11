using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScienceGram.Core.Entities;

namespace ScienceGram.Infrastructure.Data.Config
{
	public class CollaborationConfiguration : IEntityTypeConfiguration<Collaboration>
	{
		public void Configure(EntityTypeBuilder<Collaboration> builder)
		{
			builder.HasOne(w => w.User)
				.WithMany(u => u.Collaborations)
				.IsRequired(true);

			builder.HasOne(w => w.Project)
				.WithMany(l => l.Collaborations)
				.IsRequired(true);

			builder.Property(w => w.UserId).IsRequired(true);
			builder.Property(w => w.ProjectId).IsRequired(true);
		}
	}
}
