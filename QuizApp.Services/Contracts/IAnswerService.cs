using QuizApp.DTO;
using System;
using System.Threading.Tasks;

namespace QuizApp.Services.Contracts
{
    public interface IAnswerService
    {
        Task<TestAnswerDto> GetAnswerById(Guid id);
        Task<bool> Delete(Guid id);
    }
}
