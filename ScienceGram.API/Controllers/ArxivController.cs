using Microsoft.AspNetCore.Mvc;
using ScienceGram.Application.Common.Interfaces;
using ScienceGram.Application.Common.Models.Arxiv;
using System.ComponentModel.DataAnnotations;

namespace ScienceGram.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ArxivController : ControllerBase
    {
        private readonly IArxivService _arxiveService;

        public ArxivController(IArxivService arxivService)
        {
            _arxiveService = arxivService;
        }

        [HttpGet(Name = "GetArxivApi")]
        public async Task<ArxivFeed> Index([FromQuery]string? searchQuery,
            [FromQuery]string? idList,
            [FromQuery]int? start,
            [FromQuery] int? maxResults)
        {
            return await _arxiveService.GetArxiv(
                searchQuery,
                idList,
                start,
                maxResults);
        }
    }
}
