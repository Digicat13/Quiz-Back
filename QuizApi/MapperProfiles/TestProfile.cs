using AutoMapper;
using QuizApp.DAL.Entities;
using QuizApp.DTO;

namespace QuizApp.MapperProfiles
{
	public class TestProfile : Profile
	{
		public TestProfile()
		{
			CreateMap<Test, TestDto>()
				.ForMember(d => d.Questions, opt => opt.MapFrom(src => src.TestQuestions));
		}
	}
}
