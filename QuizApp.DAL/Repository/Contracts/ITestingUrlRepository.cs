using QuizApp.DAL.Entities;
using QuizApp.DAL.Helpers;
using QuizApp.DAL.QueryParameters;
using System;
using System.Threading.Tasks;

namespace QuizApp.DAL.Repository.Contracts
{
	public interface ITestingUrlRepository : IRepository<TestingUrl, Guid>
	{
		Task<PagedList<TestingUrl>> GetAllTestings(TestingParameters parameters);
	}
}
