using System;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Repository.Contracts;

namespace QuizApp.DAL.Repository.Repositories
{
	public class TestingUrlRepository : Repository<TestingUrl, Guid>, ITestingUrlRepository
	{
		public TestingUrlRepository(QuizAppContext context) : base(context)
		{
		}
	}
}
