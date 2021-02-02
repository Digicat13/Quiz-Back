using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.DAL.QueryParameters;
using QuizApp.DTO;
using QuizApp.DTO.Requests;

namespace QuizApp.Services.Contracts
{
	public interface ITestingService
	{
		Task<List<TestingDto>> GetAll(TestingParameters parameters);
		Task<TestingDto> GetTestingById(Guid id);
		Task<TestingDto> Add(CreateTestingRequest testingRequest);
		Task<TestingDto> Update(TestingDto testingRequest);
		Task<TestingDto> ReduceTestingAttempts(Guid id);
	}
}
