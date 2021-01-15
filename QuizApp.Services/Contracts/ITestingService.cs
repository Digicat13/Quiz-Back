using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizApp.DTO;
using QuizApp.DTO.Requests;

namespace QuizApp.Services.Contracts
{
	public interface ITestingService
	{
		Task<List<TestingDto>> GetAll();
		Task<TestingDto> GetTestingById(Guid id);
		Task<TestingDto> Add(CreateTestingRequest testingRequest);
	}
}
