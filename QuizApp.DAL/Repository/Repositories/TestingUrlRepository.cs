using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizApp.DAL.Entities;
using QuizApp.DAL.QueryParameters;
using QuizApp.DAL.Repository.Contracts;

namespace QuizApp.DAL.Repository.Repositories
{
	public class TestingUrlRepository : Repository<TestingUrl, Guid>, ITestingUrlRepository
	{
		public TestingUrlRepository(QuizAppContext context) : base(context)
		{
		}

		public async Task<List<TestingUrl>> GetAllTestings(TestingParameters parameters)
		{
			return await GetAll()
				.Skip((parameters.PageNumber - 1) * parameters.PageSize)
				.Take(parameters.PageSize)
				.ToListAsync();
		}
	}
}
