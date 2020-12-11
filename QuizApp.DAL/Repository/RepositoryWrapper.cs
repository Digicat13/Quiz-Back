using System.Threading.Tasks;
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

		public ITestAnswerRepository TestAnswer => _testAnswer ??= new TestAnswerRepository(_dbContext);

		public ITestingResultAnswerRepository TestingResultAnswer => _testingResultAnswer ??= new TestingResultAnswerRepository(_dbContext);

		public ITestingResultRepository TestingResult => _testingResult ??= new TestingResultRepository(_dbContext);

		public ITestingUrlRepository TestingUrl => _testingUrl ??= new TestingUrlRepository(_dbContext);

		public ITestQuestionRepository TestQuestion => _testQuestion ??= new TestQuestionRepository(_dbContext);

		public ITestRepository Test => _test ??= new TestRepository(_dbContext);

		public IUserRepository User => _user ??= new UserRepository(_dbContext);

		public RepositoryWrapper(QuizAppContext context)
		{
			_dbContext = context;
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
