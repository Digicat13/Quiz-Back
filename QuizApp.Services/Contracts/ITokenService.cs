using Microsoft.AspNetCore.Identity;

namespace QuizApp.Services.Contracts
{
    public interface ITokenService
    {
        string GetToken(IdentityUser user);
    }
}
