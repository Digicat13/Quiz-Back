﻿using QuizApp.DAL.Helpers;
using QuizApp.DAL.QueryParameters;
using QuizApp.DTO;
using QuizApp.DTO.Requests;
using QuizApp.DTO.Responses;
using System;
using System.Threading.Tasks;

namespace QuizApp.Services.Contracts
{
	public interface ITestService
    {
        Task<PagedList<TestDto>> GetAll(TestParameters parameters);
        Task<TestDto> GetTestById(Guid id);
        Task<TestUserResponse> GetUserTestById(Guid id);
        Task<TestDto> Add(CreateTestRequest testRequest);
        Task<bool> Delete(Guid id);
        Task<TestDto> Update(UpdateTestRequest testRequest);
    }
}
