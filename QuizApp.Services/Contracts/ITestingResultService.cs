using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.DTO;
using QuizApp.DTO.Requests;
using QuizApp.DTO.Responses;

namespace QuizApp.Services.Contracts
{
	public interface ITestingResultService
	{
		Task<List<TestingResultDto>> GetAll();
		Task<TestingResultUserResponse> GetTestingResultById(Guid id);
		Task<TestingResultUserResponse> Add(CreateTestingResultRequest resultRequest);
	}
}
