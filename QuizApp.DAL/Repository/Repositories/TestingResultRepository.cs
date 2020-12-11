using System;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Repository.Contracts;

namespace QuizApp.DAL.Repository.Repositories
{
	public class TestingResultRepository : Repository<TestingResult, Guid>, ITestingResultRepository
	{
		public TestingResultRepository(QuizAppContext context) : base(context)
		{
		}
	}
}
