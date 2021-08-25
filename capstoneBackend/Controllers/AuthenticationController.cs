using AutoMapper;
using capstoneBackend.ActionFilters;
using capstoneBackend.Contracts;
using capstoneBackend.DataTransferObjects;
using capstoneBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Stripe;

namespace capstoneBackend.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthenticationManager _authManager;
        private readonly APIKeys _keys = new APIKeys();
        public AuthenticationController(IMapper mapper, UserManager<User> userManager, IAuthenticationManager authManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
            StripeConfiguration.ApiKey = _keys.STRIPE_KEY;
        }

        public void StripeAccountSetup(UserForRegistrationDto userForRegistration)
        {
            var options = new AccountCreateOptions
            {
                Type = "standard",
                Email = userForRegistration.Email,
                BusinessType = "individual"
            };

            var service = new AccountService();
            var account = service.Create(options);
        }



        [HttpPost()]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Register([FromBody] UserForRegistrationDto userForRegistration)
        {

            var user = _mapper.Map<User>(userForRegistration);

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userManager.AddToRoleAsync(user, userForRegistration.Role);

            if (userForRegistration.SetUpStripe)
            {
                StripeAccountSetup(userForRegistration);
            }

            return StatusCode(201, user);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if(!await _authManager.ValidateUser(user))
            {
                return Unauthorized();
            }

            return Ok(new { Token = await _authManager.CreateToken() });
        }
    }
}
