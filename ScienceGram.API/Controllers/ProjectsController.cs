using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ScienceGram.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectsController : ControllerBase
	{
		private readonly IMediator _mediator;
		public ProjectsController(IMediator mediator)
		{
			_mediator = mediator;
		}

	}
}
