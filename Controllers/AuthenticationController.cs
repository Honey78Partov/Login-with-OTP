using LoginWithOTP.Models.Dto;
using LoginWithOTP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginWithOTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationApplication _authenticationApplication;
        public AuthenticationController(IAuthenticationApplication authenticationApplication)
        {
                _authenticationApplication = authenticationApplication;
        }
        public Task RegisterUser(RegisterUserDto registerUserDto, CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}
