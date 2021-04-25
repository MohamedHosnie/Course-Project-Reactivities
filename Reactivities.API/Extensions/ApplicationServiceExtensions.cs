using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Reactivities.Application.Activities;
using Reactivities.Application.Core;
using Reactivities.Persistence.EntityFramework;

namespace Reactivities.API.Extensions
{
	public static class ApplicationServiceExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) {
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reactivities.API", Version = "v1" });
			});
			services.AddDbContext<DataContext>(opt =>
			{
				opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
			});
			services.AddCors(opt =>
			{
				opt.AddPolicy("CorsPolicy", policy => {
					policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
				});
			});
			services.AddMediatR(typeof(List.Handler).Assembly);
			services.AddAutoMapper(typeof(MappingProfile).Assembly);

			return services;
		}		
	}
}
