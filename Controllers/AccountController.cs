using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using maskotas.DataTransferObjects;
using maskotas.Models;
using maskotas.Services;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace maskotas.Controllers
{
    [Route("/api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signinManager)
        {
            _signinManager = signinManager;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AppUser user = new AppUser
            {
                UserName = userDto.Username,
                Email = userDto.Email,
            };

            var userCreationResult = await _userManager.CreateAsync(user, userDto.Password);
            if (!userCreationResult.Succeeded)
                return StatusCode(500, userCreationResult.Errors);

            var roleAdditionResult = await _userManager.AddToRoleAsync(user, "User");
            if (!roleAdditionResult.Succeeded)
                return StatusCode(500, roleAdditionResult.Errors);

            var Token = _tokenService.CreateToken(user);
            RegisteredUserDto newUser = new RegisteredUserDto
            {
                Username = user.UserName,
                Email = user.Email,
                Token = Token
            };
            CookieOptions cookieOptions = new CookieOptions
            {
                HttpOnly = true
            };
            Response.Cookies.Append("jwtToken", Token, cookieOptions);
            return Ok(newUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userManager.FindByNameAsync(userDto.Username);
            if (user == null)
                return Unauthorized("Invalid username or password");

            var signinResult = await _signinManager.CheckPasswordSignInAsync(user, userDto.Password, false);
            if (!signinResult.Succeeded)
                return Unauthorized("Invalid username or password");

            var newUser = new RegisteredUserDto
            {
                Username = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
            return Ok(newUser);
        }
    }
}