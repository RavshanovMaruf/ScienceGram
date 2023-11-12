using ScienceGram.Application.Common.Interfaces.Repositories;
using ScienceGram.Core.Entities;
using ScienceGram.Core.Persistence.Repositories;
using ScienceGram.Infrastructure.Persistence;

namespace ScienceGram.Infrastructure.Repositories
{
	public class ProjectSkillRepository : EfBaseRepository<ProjectSkill, ApplicationDbContext>, IProjectSkillRepository
	{
		public ProjectSkillRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
