using QuizApp.DAL.Entities;
using QuizApp.DAL.Helpers;
using QuizApp.DAL.QueryParameters;
using System;
using System.Threading.Tasks;

namespace QuizApp.DAL.Repository.Contracts
{
	public interface ITestRepository : IRepository<Test, Guid>
	{
		Task<PagedList<Test>> GetAllTests(TestParameters queryParameters);
		Task<Test> GetTestById(Guid id);
	}
}
