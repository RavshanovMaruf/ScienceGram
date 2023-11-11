using ScienceGram.Application.Common.Interfaces;
using ScienceGram.Application.Common.Models.Account;

namespace ScienceGram.Infrastructure.Identity
{
	public class IdentityService : IIdentityService
	{
		public Task<LoginResponse> LoginUserAsync(LoginViewModel userModel)
		{
			throw new NotImplementedException();
		}

		public Task<RegisterResponse> RegisterUserAsync(RegisterViewModel model)
		{
			throw new NotImplementedException();
		}
	}
}
