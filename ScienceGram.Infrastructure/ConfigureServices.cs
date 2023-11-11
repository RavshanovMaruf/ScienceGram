using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ScienceGram.Application.Common.Interfaces;
using ScienceGram.Core.Entities;
using ScienceGram.Infrastructure.Common.Options;
using ScienceGram.Infrastructure.Identity;
using ScienceGram.Infrastructure.Interceptors;
using ScienceGram.Infrastructure.Persistence;
using System.Text;

namespace ScienceGram.Infrastructure
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddInfrastructureServices(
			this IServiceCollection services,
			IConfiguration configuration
		)
		{
			services.Configure<AuthSettingsOptions>(
				configuration.GetSection(AuthSettingsOptions.AuthSettings)
			);

			services.Configure<AppOptions>(configuration.GetSection(AppOptions.App));

			services.AddScoped<AuditableEntitySaveChangesInterceptor>();

			// Add DbContext service
			services.AddDbContext<ApplicationDbContext>(
				options =>
					options.UseSqlServer(
						configuration.GetConnectionString("DefaultConnection"),
						builder =>
							builder
								.EnableRetryOnFailure(maxRetryCount: 5)
								.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
					)
			);

			// Add Identity service
			services
				.AddIdentity<User, Role>(options =>
				{
					options.Password.RequiredLength = 8;
					options.Password.RequireDigit = true;
					options.Password.RequireLowercase = true;
					options.Password.RequireUppercase = true;
					options.Password.RequireNonAlphanumeric = true;
				})
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services
				.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidAudience = configuration["AuthSettings:Audience"],
						ValidIssuer = configuration["AuthSettings:Issuer"],
						RequireExpirationTime = true,
						IssuerSigningKey = new SymmetricSecurityKey(
							Encoding.UTF8.GetBytes(configuration["AuthSettings:Key"]!)
						),
						ValidateIssuerSigningKey = true
					};
				});

			services.AddScoped<IIdentityService, IdentityService>();


			return services;
		}
	}
}
