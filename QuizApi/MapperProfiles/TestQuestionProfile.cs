using AutoMapper;
using QuizApp.DAL.Entities;
using QuizApp.DTO;

namespace QuizApp.MapperProfiles
{
	public class TestQuestionProfile : Profile
	{
		public TestQuestionProfile()
		{
			CreateMap<TestQuestion, TestQuestionDto>()
				.ForMember(d => d.Answers, opt => opt.MapFrom(src => src.TestAnswers));
		}
	}
}
