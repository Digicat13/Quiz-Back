using AutoMapper;
using QuizApp.DAL.Entities;
using QuizApp.DTO;
using QuizApp.DTO.Requests;

namespace QuizApp.MapperProfiles
{
    public class TestAnswerProfile : Profile
    {
        public TestAnswerProfile()
        {
            CreateMap<TestAnswer, TestAnswerDto>();
            CreateMap<CreateTestAnswerRequest, TestAnswer>();
            CreateMap<UpdateTestAnswerRequest, TestAnswer>();
        }
    }
}
