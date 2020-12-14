using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.DTO;

namespace QuizApp.Services.Contracts
{
	public interface ITestService
	{
		Task<List<TestDto>> GetAll();
		Task<TestDto> GetTestById(Guid id);
	}
}
