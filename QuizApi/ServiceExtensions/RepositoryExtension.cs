using Microsoft.Extensions.DependencyInjection;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Helpers;
using QuizApp.DAL.Repository;
using QuizApp.DAL.Repository.Contracts;

namespace QuizApp.ServiceExtensions
{
	public static class RepositoryExtension
	{
		public static void ConfigureRepositoryWrapper(this IServiceCollection services)
		{
			services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
			services.AddScoped<ISortHelper<Test>, SortHelper<Test>>();
			services.AddScoped<ISortHelper<TestingUrl>, SortHelper<TestingUrl>>();
		}
	}
}
