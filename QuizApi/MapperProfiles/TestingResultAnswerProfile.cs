using AutoMapper;
using QuizApp.DAL.Entities;
using QuizApp.DTO;
using QuizApp.DTO.Requests;

namespace QuizApp.MapperProfiles
{
	public class TestingResultAnswerProfile : Profile
	{
		public TestingResultAnswerProfile()
		{
			CreateMap<TestingResultAnswer, TestingResultAnswerDto>();
			CreateMap<CreateTestingResultAnswerRequest, TestingResultAnswer>();
		}
	}
}
