using ScienceGram.Application.Common.Models.Account;

namespace ScienceGram.Application.Common.Interfaces
{
	public interface IIdentityService
	{
		Task<RegisterResponse> RegisterUserAsync(RegisterViewModel model);
		Task<LoginResponse> LoginUserAsync(LoginViewModel userModel);
	}
}
