using ScienceGram.Application.Common.Models.Arxiv;

namespace ScienceGram.Application.Common.Interfaces
{
    public interface IArxivService
    {
        Task<ArxivFeed> GetArxiv(string searchQuery, string idList, int? start, int? maxResults);
    }
}
