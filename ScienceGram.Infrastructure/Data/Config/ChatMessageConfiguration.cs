using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScienceGram.Core.Entities;

namespace ScienceGram.Infrastructure.Data.Config
{
	public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
	{
		public void Configure(EntityTypeBuilder<ChatMessage> builder)
		{
			builder.HasOne(s => s.Sender)
				.WithMany(s => s.SenderChatMessages)
				.IsRequired(true)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(s => s.Receiver)
				.WithMany(s => s.ReceiverChatMessages)
				.IsRequired(true)
				.OnDelete(DeleteBehavior.NoAction);

			builder.Property(s => s.Message).HasMaxLength(500).IsRequired(true);
			builder.Property(s => s.TimeStamp).IsRequired(true);
		}
	}
}
