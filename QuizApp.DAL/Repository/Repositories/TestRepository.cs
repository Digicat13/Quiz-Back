using Microsoft.EntityFrameworkCore;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Helpers;
using QuizApp.DAL.QueryParameters;
using QuizApp.DAL.Repository.Contracts;
using System;
using System.Threading.Tasks;

namespace QuizApp.DAL.Repository.Repositories
{
	public class TestRepository : Repository<Test, Guid>, ITestRepository
	{
		private ISortHelper<Test> _sortHelper;
		public TestRepository(QuizAppContext context, ISortHelper<Test> sortHelper) : base(context)
		{
			_sortHelper = sortHelper;
		}

		public async Task<PagedList<Test>> GetAllTests(TestParameters parameters)
		{
			var tests = GetAll()
					.Include(t => t.TestQuestions)
					.ThenInclude(t => t.TestAnswers);

			var sortedTests = _sortHelper.ApplySort(tests, parameters.OrderBy);

			return await PagedList<Test>
				.ToPagedList(
				sortedTests,
				parameters.PageNumber,
				parameters.PageSize);
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
