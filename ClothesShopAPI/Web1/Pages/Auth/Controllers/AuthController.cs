using AutoMapper;
using ClothesShop.Logic;
using WebLayer = ClothesShopAPI.Pages.Auth.Models;
using BussinessLayer = ClothesShop.Logic.Interfaces.Auth.Models;
using ClothesShop.Logic.Interfaces.Dress.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ClothesShop.Database.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ClothesShopAPI.Pages.Auth.Models;
using ClothesShop.Logic.Interfaces.Auth.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Cors;
namespace ClothesShopAPI.Pages.Auth.Controllers
{
    [ApiController]
    [Route("api")]
    [EnableCors]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController( IAuthService _authService)
        {
            this._authService = _authService;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();


            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<WebLayer.UserModel, BussinessLayer.UserModel>()
                );
            var model = new Mapper(config).Map<WebLayer.UserModel, BussinessLayer.UserModel>(login);

            var user = await _authService.AuthenticateUser(model);

            if (user != null)
            {
                login.Password = model.Password;
                var tokenString = GenerateJSONWebToken(login);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register()
        {
            return BadRequest();

        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisismySecretKey"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
        new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

    };
            var token = new JwtSecurityToken("Test.com",
            "Test.com",
            null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       

    }
}
