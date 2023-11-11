using Microsoft.AspNetCore.Mvc;
using ScienceGram.Application.Common.Interfaces;
using ScienceGram.Application.Common.Models.Arxiv;
using System.ComponentModel.DataAnnotations;

namespace ScienceGram.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ArxivController : ControllerBase
	{
		private readonly IArxivService _arxivService;

		public ArxivController(IArxivService arxivService)
		{
			_arxivService = arxivService;
		}

		[HttpGet("arxiv-projects")]
		public async Task<ArxivFeed> GetArxivProjects(
			[FromQuery, Required] string searchQuery,
			[FromQuery] int? start,
			[FromQuery] int? maxResults
		)
		{
			return await _arxivService.GetArxiv(searchQuery, start, maxResults);
		}
	}
}
