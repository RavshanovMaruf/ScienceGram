using ScienceGram.Application.Common.Models.Arxiv;

namespace ScienceGram.Application.Common.Interfaces
{
    public interface IArxivService
    {
        Task<ArxivFeed> GetArxiv(string query);
    }
}
