using System;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Repository.Contracts;

namespace QuizApp.DAL.Repository.Repositories
{
	public class UserRepository : Repository<User, Guid>, IUserRepository
	{
		public UserRepository(QuizAppContext context) : base(context)
		{
		}
	}
}
