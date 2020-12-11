using System;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Repository.Contracts;

namespace QuizApp.DAL.Repository.Repositories
{
	public class TestAnswerRepository : Repository<TestAnswer, Guid>, ITestAnswerRepository
	{
		public TestAnswerRepository(QuizAppContext context) : base(context)
		{
		}
	}
}
