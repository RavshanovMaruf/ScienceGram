using Microsoft.AspNetCore.Mvc;
using ScienceGram.Application.Common.Interfaces;
using ScienceGram.Application.Common.Models.Account;

namespace ScienceGram.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IIdentityService _identityService;

		public AccountController(IIdentityService identityService)
		{
			_identityService = identityService;
		}

		[HttpPost]
		[Route("sign-up")]
		public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Some properties are not valid.");
			}

			var result = await _identityService.RegisterUserAsync(model);

			if (!result.IsSuccess)
				return BadRequest(result);

			return Ok(result);
		}

		[HttpPost("sign-in")]
		public async Task<IActionResult> Login(LoginViewModel loginModel)
		{
			var result = await _identityService.LoginUserAsync(loginModel);

			if (!result.IsSuccess)
			{
				return BadRequest(result);
			}

			return Ok(result);
		}
	}
}
