using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuizApp.Services.Contracts;

namespace QuizApp.Services
{
	public class TokenService : ITokenService
	{
		IConfiguration configuration;

		public TokenService(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public string GetToken(IdentityUser user)
		{
			var utcNow = DateTime.UtcNow;

			var claims = new Claim[]
			{
						new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
						new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
						new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
						new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString())
			};

			var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
			var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
			var jwt = new JwtSecurityToken(
				signingCredentials: signingCredentials,
				claims: claims,
				notBefore: utcNow,
				expires: utcNow.AddMinutes(120)
				);

			return new JwtSecurityTokenHandler().WriteToken(jwt);
		}
	}
}
