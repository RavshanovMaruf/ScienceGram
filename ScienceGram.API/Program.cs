using Chat.Web.Data;
using Chat.Web.Helpers;
using Chat.Web.Hubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ScienceGram.API.Middlewares;
using ScienceGram.API.Services;
using ScienceGram.Application;
using ScienceGram.Application.Common.Interfaces;
using ScienceGram.Infrastructure;
using ScienceGram.Infrastructure.Persistence;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IFileValidator, FileValidator>();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();


//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ChatDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ChatConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new() { Title = "ScienceGram", Version = "v1" });

	c.AddSecurityDefinition(
		"Bearer",
		new OpenApiSecurityScheme()
		{
			Name = "Authorization",
			Type = SecuritySchemeType.ApiKey,
			Scheme = "Bearer",
			BearerFormat = "JWT",
			In = ParameterLocation.Header,
			Description =
				"JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
		}
	);

	c.AddSecurityRequirement(
		new OpenApiSecurityRequirement
		{
			{
				new OpenApiSecurityScheme
				{
					Reference = new OpenApiReference
					{
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
					}
				},
				new string[] { }
			}
		}
	);
});

// Add services to the container.
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

// So that the URLs are lowercase
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// To display enum values as strings in the response
builder.Services
	.AddControllers()
	.AddJsonOptions(
		options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
	);

builder.Services.AddCors(options =>
{
	options.AddPolicy(
		name: "CorsPolicy",
		builder =>
		{
			builder
				.WithOrigins("http://localhost:3000")
				.AllowAnyMethod()
				.AllowAnyHeader()
				.AllowCredentials();
		}
	);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();

	using var scope = app.Services.CreateScope();
	var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
	await initialiser.InitialiseAsync();
}

// So that the Swagger UI is available in production
// To invoke the Swagger UI, go to https://<host>/swagger or https://<host>/swagger/index.html
if (app.Environment.IsProduction())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScienceGram v1");
		c.RoutePrefix = "swagger";
	});
}

app.UseCors("CorsPolicy");
app.UseCustomExceptionHandler(); // Custom exception handler middleware
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseAuthorization();
app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
    endpoints.MapHub<ChatHub>("/chatHub");
});

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
