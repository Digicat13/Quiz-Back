using Microsoft.Extensions.DependencyInjection;
using QuizApp.Services;
using QuizApp.Services.Contracts;

namespace QuizApp.ServiceExtensions
{
	public static class ServiceExtension
	{
		public static void ConfigureServices(this IServiceCollection services)
		{
			services.AddScoped<ITestService, TestService>();
		}
	}
}
