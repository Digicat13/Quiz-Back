using QuizApp.DTO;
using QuizApp.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizApp.Services.Contracts
{
    public interface ITestService
    {
        Task<List<TestDto>> GetAll();
        Task<TestDto> GetTestById(Guid id);
        Task<TestDto> Add(CreateTestRequest testRequest);
        Task<bool> Delete(Guid id);
    }
}
