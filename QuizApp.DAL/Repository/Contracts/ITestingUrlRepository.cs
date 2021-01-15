using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.DAL.Entities;

namespace QuizApp.DAL.Repository.Contracts
{
	public interface ITestingUrlRepository : IRepository<TestingUrl, Guid>
	{
		Task<List<TestingUrl>> GetAllTestings();
	}
}
