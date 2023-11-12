using ScienceGram.Application.Common.Models.Arxiv;

namespace ScienceGram.Application.Common.Interfaces
{
    public interface IArxivService
    {
        Task<ArxivFeed> GetArxiv(string searchQuery, int? start, int? maxResults);
        Task<ArxivFeed> GetAllArxivProjects();
    }
}
