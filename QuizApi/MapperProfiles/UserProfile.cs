using AutoMapper;
using QuizApp.DAL.Entities;
using QuizApp.DTO.Requests;
using QuizApp.DTO.Responses;

namespace QuizApp.MapperProfiles
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<LoginRequest, User>();
			CreateMap<RegisterRequest, User>();
			CreateMap<User, LoginResponse>();
		}
	}
}
