using AutoMapper;
using QuizApp.DAL.Entities;
using QuizApp.DTO;
using QuizApp.DTO.Requests;
using QuizApp.DTO.Responses;

namespace QuizApp.MapperProfiles
{
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            CreateMap<Test, TestDto>()
                .ForMember(d => d.Questions, opt => opt.MapFrom(src => src.TestQuestions));
            CreateMap<CreateTestRequest, Test>()
                .ForMember(d => d.TestQuestions, opt => opt.MapFrom(src => src.Questions));
            CreateMap<UpdateTestRequest, Test>()
                .ForMember(d => d.TestQuestions, opt => opt.MapFrom(src => src.Questions));
            CreateMap<Test, TestUserResponse>()
                .ForMember(d => d.Questions, opt => opt.MapFrom(src => src.TestQuestions));
        }
    }
}
