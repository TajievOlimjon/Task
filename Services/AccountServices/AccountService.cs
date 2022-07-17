using Domain.AccountDto;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.AccountServices
{
    public  class AccountService
    {
        private readonly UserManager<User> _userManeger;
        private readonly IConfiguration _configuration;

        public AccountService(UserManager<User> userManeger,IConfiguration configuration )
        {
            _userManeger = userManeger;
            _configuration = configuration;
        }

        public async Task<TokenDto> Login(Login login)
        {
            var user=await _userManeger.FindByNameAsync(login.UserName);
            if (user != null)
            {
                var paswordValidator = new PasswordValidator<User>();
                var result = await paswordValidator.ValidateAsync(_userManeger,user, login.Password);
                if (!result.Succeeded)
                {
                    return null;
                }

                return await GenerateJwtToken(user);
            }
            return null;
        }
        public async Task<TokenDto> GenerateJwtToken(User user)
        {

            var roles = await _userManeger.GetRolesAsync(user);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
        };
            //addroles
            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
            );

            return new TokenDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
            };
        }

        public async Task<IdentityResult> Register(RegisterDto register)
        {
            User user = new User
            {
                UserName = register.UserName,
                Email = register.Email,
                UserDocumentId=register.UserDocumentId

            };
            var result = await _userManeger.CreateAsync(user);
            return result;
        }
    }

    public class TokenDto
    {
        public string Token { get; set; }
    }
}
