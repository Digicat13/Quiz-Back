using System;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Repository.Contracts;

namespace QuizApp.DAL.Repository.Repositories
{
	public class TestQuestionRepository : Repository<TestQuestion, Guid>, ITestQuestionRepository
	{
		public TestQuestionRepository(QuizAppContext context) : base(context)
		{
		}
	}
}
