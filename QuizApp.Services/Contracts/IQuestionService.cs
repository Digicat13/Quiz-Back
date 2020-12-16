using QuizApp.DTO;
using System;
using System.Threading.Tasks;

namespace QuizApp.Services.Contracts
{
    public interface IQuestionService
    {
        Task<TestQuestionDto> GetQuestionById(Guid id);
    }
}
