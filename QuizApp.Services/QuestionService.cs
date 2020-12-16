using AutoMapper;
using Microsoft.Extensions.Logging;
using QuizApp.DAL.Repository.Contracts;
using QuizApp.DTO;
using QuizApp.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace QuizApp.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<QuestionService> _logger;

        public QuestionService(IRepositoryWrapper repository, IMapper mapper, ILogger<QuestionService> logger)
        {
            _logger = logger;
            if (repository == null)
            {
                _logger.LogError("Failed to inject RepositoryWrapper into Question service");
            }
            else
            {
                _repository = repository;
            }
            _mapper = mapper;
        }

        public async Task<TestQuestionDto> GetQuestionById(Guid id)
        {
            var question = await _repository.TestQuestion.GetQuestionById(id);
            var result = _mapper.Map<TestQuestionDto>(question);
            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            var question = await GetQuestionById(id);
            if (question == null)
            {
                return false;
            }
            var rowsCount = await _repository.TestQuestion.Delete(id);
            return rowsCount == 0 ? false : true;
        }
    }
}
