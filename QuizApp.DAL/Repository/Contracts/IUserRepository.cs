using System;
using QuizApp.DAL.Entities;

namespace QuizApp.DAL.Repository.Contracts
{
	public interface IUserRepository : IRepository<User, Guid>
	{
	}
}
