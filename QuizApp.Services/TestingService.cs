using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using QuizApp.DAL.Entities;
using QuizApp.DAL.QueryParameters;
using QuizApp.DAL.Repository.Contracts;
using QuizApp.DTO;
using QuizApp.DTO.Requests;
using QuizApp.Services.Contracts;

namespace QuizApp.Services
{
	public class TestingService : ITestingService
	{
		private readonly IRepositoryWrapper _repository;
		private readonly IMapper _mapper;
		private readonly ILogger<TestingService> _logger;

		public TestingService(IRepositoryWrapper repository, IMapper mapper, ILogger<TestingService> logger)
		{
			_logger = logger;
			if (repository == null)
			{
				_logger.LogError("Failed to inject RepositoryWrapper into Testing service");
			}
			else
			{
				_repository = repository;
			}
			_mapper = mapper;
		}

		public async Task<List<TestingDto>> GetAll(TestingParameters parameters)
		{
			var testings = await _repository.TestingUrl.GetAllTestings(parameters);
			var result = _mapper.Map<List<TestingDto>>(testings);
			return result;
		}

		public async Task<TestingDto> GetTestingById(Guid id)
		{
			var testing = await _repository.TestingUrl.GetByIdAsync(id);
			var result = _mapper.Map<TestingDto>(testing);
			return result;
		}

		public async Task<TestingDto> Add(CreateTestingRequest testingRequest)
		{
			var testing = _mapper.Map<TestingUrl>(testingRequest);
			var rowsCount = await _repository.TestingUrl.Add(testing);
			if (rowsCount == 0)
			{
				throw new ArgumentException();
			}
			var result = await GetTestingById(testing.Id);
			if (result == null)
			{
				throw new KeyNotFoundException();
			}
			return result;
		}

		public async Task<TestingDto> Update(TestingDto testingRequest)
		{
			var testing = _mapper.Map<TestingUrl>(testingRequest);
			var rowsCount = await _repository.TestingUrl.Update(testing);
			if (rowsCount == 0)
			{
				throw new ArgumentException();
			}
			var result = await GetTestingById(testing.Id);
			return result;
		}

		public async Task<TestingDto> ReduceTestingAttempts(Guid id)
		{
			var testing = await GetTestingById(id);
			if (testing.NumberOfRuns != 0 || testing.NumberOfRuns != null)
			{
				testing.NumberOfRuns--;
				var testingRequest = _mapper.Map<TestingDto>(testing);
				var updatedTesting = await Update(testingRequest);
				return updatedTesting;
			}
			else
			{
				throw new InvalidOperationException("Number of left testing attempts is 0");
			}
		}
	}
}
