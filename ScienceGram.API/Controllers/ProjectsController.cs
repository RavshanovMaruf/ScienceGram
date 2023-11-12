using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScienceGram.Core.Entities;
using ScienceGram.Infrastructure.Persistence;

namespace ScienceGram.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectsController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly ApplicationDbContext _context;
		public ProjectsController(IMediator mediator,
			ApplicationDbContext context)
		{
			_mediator = mediator;
			_context = context;
		}
	}
}
