using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyRESTServices.BLL.DTOs;
using MyRESTServices.BLL.Interfaces;
using MyRESTServices.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyRESTServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBLL _userBLL;
        private readonly AppSettings _appSettings;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserBLL userBLL, IOptions<AppSettings> appSettings, ILogger<UsersController> logger)
        {
            _userBLL = userBLL;
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            var users = await _userBLL.GetAll();
            return users;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var user = await _userBLL.Login(loginDTO);
                if (user == null)
                {
                    return Unauthorized();
                }
                var userWithRolesDto = await _userBLL.GetUserWithRoles(user.Username);
                //_logger.LogInformation($"---------------------------> User {user.Username} logged in, {userWithRolesDto.Roles.First().RoleName}");

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, loginDTO.Username));
                foreach (var role in userWithRolesDto.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
                }
                var tokenHandler = new JwtSecurityTokenHandler();

                //_logger.LogInformation($"---------------------------> {_appSettings.Secret}");
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                //_logger.LogInformation($"---------------------------> Token generated for {tokenHandler.WriteToken(token)}");
                var tokenDto = new TokenDTO
                {
                    Username = loginDTO.Username,
                    Token = tokenHandler.WriteToken(token)
                };
                return Ok(tokenDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} - {ex.InnerException.Message}");
            }
        }

        // GET api/<UsersController>/5
        [HttpGet("GetByUser")]
        public async Task<UserDTO> Get(string username)
        {
            var user = await _userBLL.GetUserWithRoles(username);
            return user;
        }



        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCreateDTO userCreateDTO)
        {
            try
            {
                await _userBLL.Insert(userCreateDTO);
                return CreatedAtAction("Get", userCreateDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
