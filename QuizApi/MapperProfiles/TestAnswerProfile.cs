using AutoMapper;
using QuizApp.DAL.Entities;
using QuizApp.DTO;
using QuizApp.DTO.Requests;
using QuizApp.DTO.Responses;

namespace QuizApp.MapperProfiles
{
    public class TestAnswerProfile : Profile
    {
        public TestAnswerProfile()
        {
            CreateMap<TestAnswer, TestAnswerDto>();
            CreateMap<TestAnswer, TestAnswerUserResponse>();
            CreateMap<CreateTestAnswerRequest, TestAnswer>();
            CreateMap<UpdateTestAnswerRequest, TestAnswer>();
        }
    }
}
