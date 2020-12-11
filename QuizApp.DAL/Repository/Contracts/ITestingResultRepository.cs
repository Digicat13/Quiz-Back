using System;
using QuizApp.DAL.Entities;

namespace QuizApp.DAL.Repository.Contracts
{
	public interface ITestingResultRepository : IRepository<TestingResult, Guid>
	{
	}
}
