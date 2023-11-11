using ScienceGram.Core.Entities;
using ScienceGram.Core.Persistence.Repositories;

namespace ScienceGram.Application.Common.Interfaces.Repositories
{
	public interface IProjectStatusRepository : IAsyncRepository<ProjectStatus>
	{
	}
}
