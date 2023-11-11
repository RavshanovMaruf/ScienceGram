using MediatR;
using ScienceGram.Core.Common;
using ScienceGram.Infrastructure.Persistence;

namespace ScienceGram.Infrastructure.Common
{
	public static class MediatorExtensions
	{
		public static async Task DispatchDomainEvents(this IMediator mediator, ApplicationDbContext dbContext)
		{
			var entities = dbContext.ChangeTracker
				.Entries<BaseEntity>()
				.Where(e => e.Entity.DomainEvents.Any())
				.Select(e => e.Entity);

			var events = entities
				.SelectMany(e => e.DomainEvents)
				.ToList();

			entities.ToList().ForEach(e => e.ClearDomainEvents());

			foreach (var domainEvent in events)
				await mediator.Publish(domainEvent);
		}
	}
}
