using System;
using QuizApp.DAL.Entities;

namespace QuizApp.DAL.Repository.Contracts
{
	public interface ITestQuestionRepository : IRepository<TestQuestion, Guid>
	{
	}
}
