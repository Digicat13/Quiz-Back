using AutoMapper;
using QuizApp.DAL.Entities;
using QuizApp.DTO;
using QuizApp.DTO.Requests;

namespace QuizApp.MapperProfiles
{
    public class TestQuestionProfile : Profile
    {
        public TestQuestionProfile()
        {
            CreateMap<TestQuestion, TestQuestionDto>()
                .ForMember(d => d.Answers, opt => opt.MapFrom(src => src.TestAnswers));
            CreateMap<CreateTestQuestionRequest, TestQuestion>()
                .ForMember(d => d.TestAnswers, opt => opt.MapFrom(src => src.Answers));
            CreateMap<UpdateTestQuestionRequest, TestQuestion>()
                .ForMember(d => d.TestAnswers, opt => opt.MapFrom(src => src.Answers));
        }
    }
}
