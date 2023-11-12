using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScienceGram.Application.Features.Projects.Commands.Create;
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

		[HttpPost]
		public async Task<IActionResult> Create([FromForm] CreateProjectCommand createProjectCommand)
		{
			var result = await _mediator.Send(createProjectCommand);
			return Ok(result);
		}

		//[HttpGet("{id}")]
		//public async Task<IActionResult> GetById([FromRoute] int id)
		//{
		//	var result = await _mediator.Send(new GetByIdQuery(id));
		//	return Ok(result);
		//}

		//[HttpGet]
		//public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
		//{
		//	var query = new GetAllProjectsQuery { PageRequest = pageRequest };
		//	var projects = await _mediator.Send(query);

		//	return Ok(projects);
		//}

	}
}
