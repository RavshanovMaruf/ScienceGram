using ScienceGram.Core.Entities;
using ScienceGram.Core.Persistence.Repositories;

namespace ScienceGram.Application.Common.Interfaces.Repositories
{
	public interface ICategoryRepository : IAsyncRepository<Category>
	{
	}
}
