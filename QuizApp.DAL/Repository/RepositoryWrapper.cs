using System.Threading.Tasks;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Helpers;
using QuizApp.DAL.Repository.Contracts;
using QuizApp.DAL.Repository.Repositories;

namespace QuizApp.DAL.Repository
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private QuizAppContext _dbContext;
		private ITestAnswerRepository _testAnswer;
		private ITestingResultAnswerRepository _testingResultAnswer;
		private ITestingResultRepository _testingResult;
		private ITestingUrlRepository _testingUrl;
		private ITestQuestionRepository _testQuestion;
		private ITestRepository _test;
		private IUserRepository _user;
		private ISortHelper<Test> _testSortHelper;
		private ISortHelper<TestingUrl> _testingSortHelper;

		public ITestAnswerRepository TestAnswer => _testAnswer ??= new TestAnswerRepository(_dbContext);

		public ITestingResultAnswerRepository TestingResultAnswer => _testingResultAnswer ??= new TestingResultAnswerRepository(_dbContext);

		public ITestingResultRepository TestingResult => _testingResult ??= new TestingResultRepository(_dbContext);

		public ITestingUrlRepository TestingUrl => _testingUrl ??= new TestingUrlRepository(_dbContext, _testingSortHelper);

		public ITestQuestionRepository TestQuestion => _testQuestion ??= new TestQuestionRepository(_dbContext);

		public ITestRepository Test => _test ??= new TestRepository(_dbContext, _testSortHelper);

		public IUserRepository User => _user ??= new UserRepository(_dbContext);

		public RepositoryWrapper(QuizAppContext context, ISortHelper<Test> testSortHelper, ISortHelper<TestingUrl> testingSortHelper)
		{
			_dbContext = context;
			_testSortHelper = testSortHelper;
			_testingSortHelper = testingSortHelper;
		}

		public void Save()
		{
			_dbContext.SaveChanges();
		}

		public async Task SaveAsync()
		{
			await _dbContext.SaveChangesAsync();
		}
	}
}
