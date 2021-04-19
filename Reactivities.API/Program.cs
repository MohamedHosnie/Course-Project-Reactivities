using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Reactivities.Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reactivities.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			using var scope = host.Services.CreateScope();

			UseServices(scope);

			host.Run();
		}

		private static void UseServices(IServiceScope scope)
		{
			var services = scope.ServiceProvider;
			
			try {
				var context = services.GetRequiredService<DataContext>();
				context.Database.Migrate();

			} catch(Exception e) {
				var logger = services.GetRequiredService<ILogger<Program>>();
				logger.LogError(e, "An error occured during migration");

			}
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}