using ScienceGram.Application.Common.Interfaces.Repositories;
using ScienceGram.Core.Entities;
using ScienceGram.Core.Persistence.Repositories;
using ScienceGram.Infrastructure.Persistence;

namespace ScienceGram.Infrastructure.Repositories
{
	public class EducationRepository : EfBaseRepository<Education, ApplicationDbContext>, IEducationRepository
	{
		public EducationRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
