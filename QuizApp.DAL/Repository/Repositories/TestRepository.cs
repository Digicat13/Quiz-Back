using System;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Repository.Contracts;

namespace QuizApp.DAL.Repository.Repositories
{
	public class TestRepository : Repository<Test, Guid>, ITestRepository
	{
		public TestRepository(QuizAppContext context) : base(context)
		{
		}
	}
}
