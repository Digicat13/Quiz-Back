using AutoMapper;
using Microsoft.Extensions.Logging;
using QuizApp.DAL.Repository.Contracts;
using QuizApp.DTO;
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
    }
}
