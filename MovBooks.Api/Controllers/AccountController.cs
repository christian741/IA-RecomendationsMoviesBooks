using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovBooks.Core.DTOs;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovBooks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _haccess;
        private readonly IUserService _userService;

        public AccountController(IMapper mapper, IUserService userService, IConfiguration configuration, IHttpContextAccessor haccess)
        {
            _mapper = mapper;
            _haccess = haccess;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetUserByToken()
        {
            var claimsIdentity = _haccess.HttpContext.User.Identity as ClaimsIdentity;
            var userClaim = claimsIdentity.FindFirst("user");
            var user = JsonConvert.DeserializeObject<User>(userClaim.Value);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin login)
        {
            // If it is a valid user
            var validation = await IsValidUser(login);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token, userDetails = validation.Item2 });
            }

            return NotFound(new { message = "Usuario y/o contraseña incorrectas" });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userService.Insert(user);
            user.Role = new Role
            {
                Id = user.RoleId,
                Name = user.RoleId == 1 ? "User" : "Admin"
            };
            return Ok(new
            {
                token = GenerateToken(user),
                userDetails = user
            });
        }

        private async Task<(bool, User)> IsValidUser(UserLogin login)
        {
            var user = await _userService.GetLoginByCredentials(login);
            if (user == null)
            {
                return (false, user);
            }
            return (user != null, user);
        }

        private string GenerateToken(User user)
        {
            // Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            // Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Nickname),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.Name),
                new Claim("user", JsonConvert.SerializeObject(
                        user, Formatting.Indented,
                        new JsonSerializerSettings { ReferenceLoopHandling  = ReferenceLoopHandling.Ignore }
                  )
                )
            };

            // Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.Now.AddDays(1)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
