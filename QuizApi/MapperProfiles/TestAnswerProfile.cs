using AutoMapper;
using QuizApp.DAL.Entities;
using QuizApp.DTO;

namespace QuizApp.MapperProfiles
{
	public class TestAnswerProfile : Profile
	{
		public TestAnswerProfile()
		{
			CreateMap<TestAnswer, TestAnswerDto>();
		}
	}
}
