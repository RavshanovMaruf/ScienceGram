using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ScienceGram.Application.Common.Behaviours;
using System.Reflection;

namespace ScienceGram.Application
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddMediatR(config =>
			{
				config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
			});

			ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("en-US");

			return services;
		}
	}
}
