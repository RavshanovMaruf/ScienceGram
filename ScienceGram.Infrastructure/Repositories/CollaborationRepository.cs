using ScienceGram.Application.Common.Interfaces.Repositories;
using ScienceGram.Core.Entities;
using ScienceGram.Core.Persistence.Repositories;
using ScienceGram.Infrastructure.Persistence;

namespace ScienceGram.Infrastructure.Repositories
{
	public class CollaborationRepository : EfBaseRepository<Collaboration, ApplicationDbContext>, ICollaborationRepository
	{
		public CollaborationRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
