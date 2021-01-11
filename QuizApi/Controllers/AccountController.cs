using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizApp.DTO.Requests;
using QuizApp.Services.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _logger = logger;

            if (accountService == null)
            {
                _logger.LogError("Failed to inject AccountService into Account controller");
            }
            else
            {
                _accountService = accountService;
            }
        }

        [HttpPost]
        [Route("signup")]
        [AllowAnonymous]
        public async Task<ActionResult> SignUp(RegisterRequest registerRequest)
        {
            try
            {
                var result = await _accountService.Register(registerRequest);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error " + e.Message);
            }
        }

        [HttpPost]
        [Route("signin")]
        [AllowAnonymous]
        public async Task<ActionResult> SignIn(LoginRequest loginRequest)
        {
            try
            {
                var result = await _accountService.Login(loginRequest);
                return Ok(result);
            }
            catch (FormatException e)
            {
                return StatusCode(401, "Wrong credentials");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error " + e.Message);
            }
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<ActionResult> RefreshToken()
        {
            try
            {
                var username = User.Identity.Name ??
                User.Claims.Where(c => c.Properties.ContainsKey("unique_name")).Select(c => c.Value).FirstOrDefault();
                var result = await _accountService.RefreshToken(username);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(401, e.Message);
            }
        }

        [HttpPost]
        [Route("signout")]
        public async new Task<ActionResult> SignOut()
        {
            try
            {
                await _accountService.SignOut();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error " + e.Message);
            }
        }
    }
}
