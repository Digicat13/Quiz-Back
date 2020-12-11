using System.Threading.Tasks;

namespace QuizApp.DAL.Repository.Contracts
{
	public interface IRepositoryWrapper
	{
		ITestAnswerRepository TestAnswer { get; }
		ITestingResultAnswerRepository TestingResultAnswer { get; }
		ITestingResultRepository TestingResult { get; }
		ITestingUrlRepository TestingUrl { get; }
		ITestQuestionRepository TestQuestion { get; }
		ITestRepository Test { get; }
		IUserRepository User { get; }
		void Save();
		Task SaveAsync();
	}
}
