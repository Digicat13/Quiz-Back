using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizApp.DAL.Entities;
using QuizApp.DAL.Repository.Contracts;

namespace QuizApp.DAL.Repository.Repositories
{
	public class TestingResultAnswerRepository : Repository<TestingResultAnswer, Guid>, ITestingResultAnswerRepository
	{
		public TestingResultAnswerRepository(QuizAppContext context) : base(context)
		{
		}
	}
}
