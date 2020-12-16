using AutoMapper;
using Microsoft.Extensions.Logging;
using QuizApp.DAL.Repository.Contracts;
using QuizApp.DTO;
using QuizApp.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace QuizApp.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<AnswerService> _logger;

        public AnswerService(IRepositoryWrapper repository, IMapper mapper, ILogger<AnswerService> logger)
        {
            _logger = logger;
            if (repository == null)
            {
                _logger.LogError("Failed to inject RepositoryWrapper into Answer service");
            }
            else
            {
                _repository = repository;
            }
            _mapper = mapper;
        }

        public async Task<TestAnswerDto> GetAnswerById(Guid id)
        {
            var answer = await _repository.TestAnswer.GetByIdAsync(id);
            var result = _mapper.Map<TestAnswerDto>(answer);
            return result;
        }
    }
}
