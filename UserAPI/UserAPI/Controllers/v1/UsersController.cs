using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserAPI.Contracts.Dtos;
using UserAPI.Domain.Configurations;
using UserAPI.Engines.Interfaces;

namespace UserAPI.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserEngine _userEngine;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        public UsersController(AppSettings appSettings, IMapper mapper, IUserEngine userEngine)
        {
            _appSettings = appSettings;
            _mapper = mapper;
            _userEngine = userEngine;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUser authenticateUser)
        {
            var user = await _userEngine.AuthenticateAsync(authenticateUser.UserName, authenticateUser.Password);

            if (user == null)
                return BadRequest(new { message = "UserName or Password is incorrect." });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.Now.AddMinutes(_appSettings.TokenLifeInMin),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Claims = new Dictionary<string, object>()
            };

            tokenDescriptor.Claims.Add("Id", user.Id);
            tokenDescriptor.Claims.Add("UserName", user.UserName);

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User model)
        {
            try
            {
                var user = new Domain.Models.User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName
                };
                // create user
                user = await _userEngine.CreateAsync(user, model.Password);

                return Created("", _mapper.Map<User>(user));
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var user = await _userEngine.GetUserByIdAsync(userId);
            return Ok(_mapper.Map<User>(user));
        }
    }
}
