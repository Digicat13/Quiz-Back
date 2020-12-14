using Microsoft.EntityFrameworkCore;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizApp.DAL.Repository.Repositories
{
    public class TestRepository : Repository<Test, Guid>, ITestRepository
    {
        public TestRepository(QuizAppContext context) : base(context)
        {
        }

        public async Task<List<Test>> GetAllTests()
        {
            return await GetAll()
                .Include(t => t.TestQuestions)
                .ThenInclude(t => t.TestAnswers)
                .ToListAsync();
        }

        public async Task<Test> GetTestById(Guid id)
        {
            return await GetAll()
                .Include(t => t.TestQuestions)
                .ThenInclude(t => t.TestAnswers)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
