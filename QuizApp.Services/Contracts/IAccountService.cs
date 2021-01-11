using QuizApp.DAL.Entities;
using QuizApp.DTO.Requests;
using QuizApp.DTO.Responses;
using System.Threading.Tasks;

namespace QuizApp.Services.Contracts
{
    public interface IAccountService
    {
        Task<LoginResponse> Register(RegisterRequest registerRequest);
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<LoginResponse> RefreshToken(string username);
        Task SignOut();
    }
}
