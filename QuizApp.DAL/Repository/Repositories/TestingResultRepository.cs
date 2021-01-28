using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Repository.Contracts;

namespace QuizApp.DAL.Repository.Repositories
{
	public class TestingResultRepository : Repository<TestingResult, Guid>, ITestingResultRepository
	{
		public TestingResultRepository(QuizAppContext context) : base(context)
		{
		}

		public async Task<List<TestingResult>> GetAllTestingResults()
		{
			return await GetAll()
				.Include(t => t.TestingResultAnswers)
				.ThenInclude(a => a.TestQuestion)
				.ThenInclude(q => q.TestAnswers)
				.Include(a => a.TestingResultAnswers)
				.ThenInclude(a => a.TestAnswer)
				.ToListAsync();
		}

		public async Task<TestingResult> GetTestingResultById(Guid id)
		{
			return await GetAll()
				.Include(t => t.TestingResultAnswers)
				.ThenInclude(a => a.TestQuestion)
				.ThenInclude(q => q.TestAnswers)
				.AsNoTracking()
				.Include(a => a.TestingResultAnswers)
				.ThenInclude(a => a.TestAnswer)
				.AsNoTracking()
				.Include(t => t.TestingUrl)
				.ThenInclude(t => t.Test)
				.AsNoTracking()
				.FirstOrDefaultAsync(t => t.Id == id);
		}
	}
}
