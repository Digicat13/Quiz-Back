using QuizApp.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace QuizApp.DAL.Repository.Contracts
{
    public interface ITestQuestionRepository : IRepository<TestQuestion, Guid>
    {
        Task<TestQuestion> GetQuestionById(Guid id);
    }
}
