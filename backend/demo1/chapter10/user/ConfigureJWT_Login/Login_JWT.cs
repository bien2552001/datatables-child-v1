using demo1.chapter10.Interface;
using demo1.chapter10.model.userDto;
using demo1.chapter10.model.usermodel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;

namespace demo1.chapter10.user.ConfigureJWT_Login
{

    public class Login_JWT : ILogin_JWT
    {
        private readonly UserManager<User_Model> _userManager;

        private readonly IConfiguration _configuration;
        private User_Model _userModel;


        public Login_JWT(UserManager<User_Model> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }



        //LOGIN 

        public async Task<bool> ValidateUser(LoginRequestDto userForAuth)
        {
            _userModel = await _userManager.FindByEmailAsync(userForAuth.Email);
            return (_userModel != null && await _userManager.CheckPasswordAsync(_userModel, userForAuth.Password));
        }


        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();

            var claims = await GetClaims();

            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);


            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }


        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));

            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }


        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, _userModel.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_userModel);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }


        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings.GetSection("validIssuer").Value,

                audience: jwtSettings.GetSection("validAudience").Value,

                claims: claims,

                expires: DateTime.Now.AddMinutes(1),

                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }
    }
}
