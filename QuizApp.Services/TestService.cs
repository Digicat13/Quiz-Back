using AutoMapper;
using Microsoft.Extensions.Logging;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Repository.Contracts;
using QuizApp.DTO;
using QuizApp.DTO.Requests;
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

        public TestService(IRepositoryWrapper repository, IMapper mapper, ILogger<TestService> logger)
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
        }

        public async Task<List<TestDto>> GetAll()
        {
            var tests = await _repository.Test.GetAllTests();
            var result = _mapper.Map<List<TestDto>>(tests);
            return result;
        }

        public async Task<TestDto> GetTestById(Guid id)
        {
            var test = await _repository.Test.GetTestById(id);
            var result = _mapper.Map<TestDto>(test);
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
