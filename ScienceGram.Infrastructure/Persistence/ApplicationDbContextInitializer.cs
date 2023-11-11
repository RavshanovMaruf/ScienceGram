using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScienceGram.Core.Entities;

namespace ScienceGram.Infrastructure.Persistence
{
	public class ApplicationDbContextInitializer
	{
		private readonly ILogger<ApplicationDbContextInitializer> _logger;
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<Role> _roleManager;

		public ApplicationDbContextInitializer(
			ILogger<ApplicationDbContextInitializer> logger,
			ApplicationDbContext context,
			UserManager<User> userManager,
			RoleManager<Role> roleManager
		)
		{
			_logger = logger;
			_context = context;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async Task InitialiseAsync()
		{
			try
			{
				if (_context.Database.IsSqlServer())
				{
					await _context.Database.MigrateAsync();
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while initialising the database.");
				throw;
			}
		}

	}
}
