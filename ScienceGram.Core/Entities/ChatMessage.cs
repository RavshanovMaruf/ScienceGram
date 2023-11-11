using ScienceGram.Core.Common;

namespace ScienceGram.Core.Entities
{
	public class ChatMessage : BaseAuditableEntity
	{
		public int SenderId { get; set; }
		public virtual User Sender { get; set; }
		public int ReceiverId { get; set; }
		public virtual User Receiver { get; set; }
		public string Message { get; set; }
		public virtual DateTime TimeStamp { get; set; }
		public int ProjectId { get; set; }
		public virtual Project Project { get; set; }
	}
}
