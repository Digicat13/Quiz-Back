using QuizApp.DAL.Entities;
using QuizApp.DAL.Helpers;
using QuizApp.DAL.QueryParameters;
using QuizApp.DAL.Repository.Contracts;
using System;
using System.Threading.Tasks;

namespace QuizApp.DAL.Repository.Repositories
{
	public class TestingUrlRepository : Repository<TestingUrl, Guid>, ITestingUrlRepository
	{
		private ISortHelper<TestingUrl> _sortHelper;
		public TestingUrlRepository(QuizAppContext context, ISortHelper<TestingUrl> sortHelper) : base(context)
		{
			_sortHelper = sortHelper;
		}

		public async Task<PagedList<TestingUrl>> GetAllTestings(TestingParameters parameters)
		{
			var testings = GetAll();

			var sortedTestings = _sortHelper.ApplySort(testings, parameters.OrderBy);

			return await PagedList<TestingUrl>
				.ToPagedList(sortedTestings,
					parameters.PageNumber,
					parameters.PageSize);
		}
	}
}
