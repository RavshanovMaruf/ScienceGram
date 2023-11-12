using ScienceGram.Application.Common.Interfaces.Repositories;
using ScienceGram.Core.Entities;
using ScienceGram.Core.Persistence.Repositories;
using ScienceGram.Infrastructure.Persistence;

namespace ScienceGram.Infrastructure.Repositories
{
	public class ExperienceRepository : EfBaseRepository<Experience, ApplicationDbContext>, IExperienceRepository
	{
		public ExperienceRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
