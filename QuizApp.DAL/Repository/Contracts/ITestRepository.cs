using System;
using QuizApp.DAL.Entities;

namespace QuizApp.DAL.Repository.Contracts
{
	public interface ITestRepository : IRepository<Test, Guid>
	{
	}
}
