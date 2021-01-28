using AutoMapper;
using QuizApp.DAL.Entities;
using QuizApp.DTO;
using QuizApp.DTO.Requests;

namespace QuizApp.MapperProfiles
{
	public class TestingProfile : Profile
	{
		public TestingProfile()
		{
			CreateMap<TestingUrl, TestingDto>()
				.ReverseMap();
			CreateMap<CreateTestingRequest, TestingUrl>();
		}
	}
}
