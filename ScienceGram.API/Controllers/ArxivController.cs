using Microsoft.AspNetCore.Mvc;
using ScienceGram.Application.Common.Interfaces;
using ScienceGram.Application.Common.Models.Arxiv;

namespace ScienceGram.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ArxivController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IArxivService _arxiveService;

        public ArxivController(IHttpClientFactory clientFactory,
            IArxivService arxivService)
        {
            _arxiveService = arxivService;
            _clientFactory = clientFactory;
        }

        [HttpGet(Name = "GetArxivApi")]
        public async Task<ArxivFeed> Index(string query)
        {
            return await _arxiveService.GetArxiv(query);
        }
    }
}
