using ScienceGram.Application.Common.Interfaces.Repositories;
using ScienceGram.Core.Entities;
using ScienceGram.Core.Persistence.Repositories;
using ScienceGram.Infrastructure.Persistence;

namespace ScienceGram.Infrastructure.Repositories
{
	public class ProjectLanguageRepository : EfBaseRepository<ProjectLanguage, ApplicationDbContext>, IProjectLanguageRepository
	{
		public ProjectLanguageRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
