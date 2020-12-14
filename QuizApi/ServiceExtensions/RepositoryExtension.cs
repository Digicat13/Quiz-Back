using Microsoft.Extensions.DependencyInjection;
using QuizApp.DAL.Repository;
using QuizApp.DAL.Repository.Contracts;

namespace QuizApp.ServiceExtensions
{
	public static class RepositoryExtension
	{
		public static void ConfigureRepositoryWrapper(this IServiceCollection services)
		{
			services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
		}
	}
}
