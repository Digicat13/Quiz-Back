using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.DAL.Entities;

namespace QuizApp.DAL.Repository.Contracts
{
	public interface ITestingResultRepository : IRepository<TestingResult, Guid>
	{
		Task<List<TestingResult>> GetAllTestingResults();
		Task<TestingResult> GetTestingResultById(Guid id);
	}
}
