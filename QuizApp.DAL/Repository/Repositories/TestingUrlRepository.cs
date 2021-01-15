using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Repository.Contracts;

namespace QuizApp.DAL.Repository.Repositories
{
	public class TestingUrlRepository : Repository<TestingUrl, Guid>, ITestingUrlRepository
	{
		public TestingUrlRepository(QuizAppContext context) : base(context)
		{
		}

		public async Task<List<TestingUrl>> GetAllTestings()
		{
			return await GetAll()
				.ToListAsync();
		}
	}
}
