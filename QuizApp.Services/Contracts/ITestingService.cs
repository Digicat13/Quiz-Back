using QuizApp.DAL.Helpers;
using QuizApp.DAL.QueryParameters;
using QuizApp.DTO;
using QuizApp.DTO.Requests;
using System;
using System.Threading.Tasks;

namespace QuizApp.Services.Contracts
{
	public interface ITestingService
	{
		Task<PagedList<TestingDto>> GetAll(TestingParameters parameters);
		Task<TestingDto> GetTestingById(Guid id);
		Task<TestingDto> Add(CreateTestingRequest testingRequest);
		Task<TestingDto> Update(TestingDto testingRequest);
		Task<TestingDto> ReduceTestingAttempts(TestingDto id);
	}
}
