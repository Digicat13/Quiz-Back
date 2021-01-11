using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using QuizApp.DAL.Entities;
using QuizApp.DTO.Requests;
using QuizApp.DTO.Responses;
using QuizApp.Services.Contracts;

namespace QuizApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AccountService> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountService(
            IMapper mapper,
            ILogger<AccountService> logger,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ITokenService tokenService)
        {
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            if (tokenService == null)
            {
                _logger.LogError("Failed to inject TokenService into Account service");
            }
            else
            {
                _tokenService = tokenService;
            }
        }


        public async Task<LoginResponse> Register(RegisterRequest registerRequest)
        {
            var user = _mapper.Map<User>(registerRequest);
            var identityResult = await _userManager.CreateAsync(user, registerRequest.Password);
            if (identityResult.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                var result = _mapper.Map<LoginResponse>(user);
                result.Token = _tokenService.GetToken(user);
                return result;
            }
            else
            {
                throw new FormatException();
            }

        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var loginResult = await _signInManager.PasswordSignInAsync(
                                        loginRequest.Username,
                                        loginRequest.Password,
                                        isPersistent: false,
                                        lockoutOnFailure: false);
            if (!loginResult.Succeeded)
            {
                throw new FormatException("Sign in failed");
            }

            var user = await _userManager.FindByNameAsync(loginRequest.Username);
            var result = _mapper.Map<LoginResponse>(user);
            result.Token = _tokenService.GetToken(user);
            return result;
        }

        public async Task<LoginResponse> RefreshToken(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var _user = await _userManager.FindByIdAsync(user.Id.ToString());
            if (_user != null)
            {
                var result = _mapper.Map<LoginResponse>(_user);
                result.Token = _tokenService.GetToken(_user);
                return result;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
