using Microsoft.EntityFrameworkCore;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Repository.Contracts;
using System;
using System.Threading.Tasks;

namespace QuizApp.DAL.Repository.Repositories
{
    public class TestQuestionRepository : Repository<TestQuestion, Guid>, ITestQuestionRepository
    {
        public TestQuestionRepository(QuizAppContext context) : base(context)
        {
        }

        public async Task<TestQuestion> GetQuestionById(Guid id)
        {
            return await GetAll()
                .Include(t => t.TestAnswers)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
