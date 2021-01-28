using AutoMapper;
using QuizApp.DAL.Entities;
using QuizApp.DTO;
using QuizApp.DTO.Requests;
using QuizApp.DTO.Responses;

namespace QuizApp.MapperProfiles
{
	public class TestingResultProfile : Profile
	{
		public TestingResultProfile()
		{
			CreateMap<TestingResult, TestingResultDto>()
				.ForMember(d => d.SelectedAnswers, opt => opt.MapFrom(src => src.TestingResultAnswers))
				.ForMember(d => d.TestingId, opt => opt.MapFrom(src => src.TestingUrlId));
			CreateMap<TestingResult, TestingResultUserResponse>()
				.ForMember(d => d.SelectedAnswers, opt => opt.MapFrom(src => src.TestingResultAnswers))
				.ForMember(d => d.TestingId, opt => opt.MapFrom(src => src.TestingUrlId))
				.ForMember(d => d.TestName, opt => opt.MapFrom(src => src.TestingUrl.Test.Name));
			CreateMap<CreateTestingResultRequest, TestingResult>()
				.ForMember(d => d.TestingResultAnswers, opt => opt.MapFrom(src => src.SelectedAnswers))
				.ForMember(d => d.TestingUrlId, opt => opt.MapFrom(src => src.TestingId));
		}
	}
}
