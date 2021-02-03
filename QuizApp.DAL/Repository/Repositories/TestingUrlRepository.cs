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

		public async Task<PagedList<TestingUrl>> GetAllTestings(TestingParameters parameters)
		{
			return await PagedList<TestingUrl>
				.ToPagedList(GetAll(),
					parameters.PageNumber,
					parameters.PageSize);
		}
	}
}
