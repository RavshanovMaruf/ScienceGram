﻿namespace ScienceGram.Application.Common.Models.Account
{
	public class TokenModel
	{
		public string AccessToken { get; set; }
		public DateTime? ExpireDate { get; set; }
		public string Role { get; set; }
	}
}