using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.ServiceExtensions
{
	public static class AuthenticationExtension
	{
		public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
		{
			var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(config =>
			{
				config.Events = new JwtBearerEvents();
				config.Events.OnChallenge = context =>
				{
					context.HandleResponse();
					var payload = new JObject
					{
						["error"] = context.Error,
						["error_description"] = context.ErrorDescription,
						["error_uri"] = context.ErrorUri
					};
					context.Response.ContentType = "application/json";
					context.Response.StatusCode = 401;

					return context.Response.WriteAsync(payload.ToString());
				};


				config.RequireHttpsMetadata = false;
				config.SaveToken = true;
				config.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = signingKey,
					ValidateAudience = false,
					ValidateIssuer = false,
					ValidateLifetime = true,
					RequireExpirationTime = false
				};
			});
		}
	}
}