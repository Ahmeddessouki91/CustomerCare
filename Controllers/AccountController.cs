using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CustomerCare.Controllers.Resources.UserResouce;
using CustomerCare.Core;
using CustomerCare.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CustomerCare.Controllers
{
    [Route("/api/[Controller]")]
    public class AccountController : Controller
    {
        private readonly IAuthRepository _authRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _uow;
        public AccountController(IAuthRepository authRepo, IMapper mapper, IConfiguration config, IUnitOfWork uow)
        {
            this._uow = uow;
            this._config = config;
            this._mapper = mapper;
            this._authRepo = authRepo;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginResource user)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dbUser = await _authRepo.Login(user.Email, user.Password);
            if (dbUser == null)
                return Unauthorized();
            if (dbUser.Deactive)
                return BadRequest("Your account has been locked by admin!");

            var token = GenerateToken(dbUser);
            return Ok(new { token });
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserSaveResource user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (await _authRepo.UserExist(user.Email))
                return BadRequest("Email is already registered!");

            user.Deactive = true;
            var userToCreate = _mapper.Map<UserSaveResource, User>(user);

            await _authRepo.Register(userToCreate, user.Password);
            await _uow.CompleteAsyn();

            return StatusCode(201);
        }

        private string GenerateToken(User dbUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.NameIdentifier,dbUser.Id.ToString()),
                        new Claim(ClaimTypes.Email,dbUser.Email),
                        new Claim(ClaimTypes.Name,dbUser.Name),
                        new Claim(ClaimTypes.Role,dbUser.IsAdmin.ToString())
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}