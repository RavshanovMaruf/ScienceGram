using ScienceGram.Application.Common.Models.BaseModels;

namespace ScienceGram.Application.Common.Models.Account
{
	public class LoginResponse : BaseResponse
	{
		public TokenModel Result { get; set; }
	}
}
