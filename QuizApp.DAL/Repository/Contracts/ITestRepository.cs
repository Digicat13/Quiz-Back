using QuizApp.DAL.Entities;
using QuizApp.DAL.QueryParameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizApp.DAL.Repository.Contracts
{
    public interface ITestRepository : IRepository<Test, Guid>
    {
        Task<List<Test>> GetAllTests(TestParameters queryParameters);
        Task<Test> GetTestById(Guid id);
    }
}
