using AutoMapper;
using Microsoft.Extensions.Logging;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Helpers;
using QuizApp.DAL.QueryParameters;
using QuizApp.DAL.Repository.Contracts;
using QuizApp.DTO;
using QuizApp.DTO.Requests;
using QuizApp.DTO.Responses;
using QuizApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizApp.Services
{
	public class TestService : ITestService
	{
		private readonly IRepositoryWrapper _repository;
		private readonly IMapper _mapper;
		private readonly ILogger<TestService> _logger;
		private readonly IAnswerService _answerService;

		public TestService(IRepositoryWrapper repository, IMapper mapper, ILogger<TestService> logger, IAnswerService answerService)
		{
			_logger = logger;
			if (repository == null)
			{
				_logger.LogError("Failed to inject RepositoryWrapper into Test service");
			}
			else
			{
				_repository = repository;
			}
			_mapper = mapper;
			_answerService = answerService;
		}

		public async Task<PagedList<TestDto>> GetAll(TestParameters parameters)
		{
			var tests = await _repository.Test.GetAllTests(parameters);
			var result = new PagedList<TestDto>(_mapper.Map<List<TestDto>>(tests), tests.TotalCount, tests.CurrentPage, tests.PageSize);
			return result;
		}

		public async Task<TestDto> GetTestById(Guid id)
		{
			var test = await _repository.Test.GetTestById(id);
			var result = _mapper.Map<TestDto>(test);
			return result;
		}

		public async Task<TestUserResponse> GetUserTestById(Guid id)
		{
			var test = await _repository.Test.GetTestById(id);

			var result = _mapper.Map<TestUserResponse>(test);
			foreach (var question in result.Questions)
			{
				foreach (var answer in question.Answers)
				{
					var _answer = await _answerService.GetAnswerById(answer.Id);
					if (_answer.IsCorrect)
					{
						question.CorrectAnswersCount++;
					}
				}
			}
			return result;
		}

		public async Task<TestDto> Add(CreateTestRequest testRequest)
		{
			var test = _mapper.Map<Test>(testRequest);
			var rowsCount = await _repository.Test.Add(test);
			if (rowsCount == 0)
			{
				throw new ArgumentException();
			}
			var result = await GetTestById(test.Id);
			if (result == null)
			{
				throw new KeyNotFoundException();
			}
			return result;
		}

		public async Task<bool> Delete(Guid id)
		{
			var test = await GetTestById(id);
			if (test == null)
			{
				return false;
			}
			var rowsCount = await _repository.Test.Delete(id);
			return rowsCount == 0 ? false : true;
		}

		public async Task<TestDto> Update(UpdateTestRequest testRequest)
		{
			var test = _mapper.Map<Test>(testRequest);
			var rowsCount = await _repository.Test.Update(test);
			if (rowsCount == 0)
			{
				throw new ArgumentException();
			}
			var result = await GetTestById(test.Id);
			return result;
		}
	}
}
