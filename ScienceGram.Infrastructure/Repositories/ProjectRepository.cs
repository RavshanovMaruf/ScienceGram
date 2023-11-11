using ScienceGram.Application.Common.Interfaces.Repositories;
using ScienceGram.Core.Entities;
using ScienceGram.Core.Persistence.Repositories;
using ScienceGram.Infrastructure.Persistence;

namespace ScienceGram.Infrastructure.Repositories
{
	public class ProjectRepository : EfBaseRepository<Project, ApplicationDbContext>, IProjectRepository
	{
		public ProjectRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
