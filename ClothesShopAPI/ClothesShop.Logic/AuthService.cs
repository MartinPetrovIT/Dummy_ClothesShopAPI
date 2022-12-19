using ClothesShoAPI.Database;
using ClothesShop.Logic.Interfaces.Auth.Models;
using ClothesShop.Logic.Interfaces.Auth.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Logic
{
    public class AuthService : IAuthService
    {

        private readonly ApplicationDBContext data;

        public AuthService(ApplicationDBContext data)
        {
            this.data = data;
        }
        public  Task<UserModel> AuthenticateUser(UserModel model)
        {
           var hashedPassword =  HasherService.ComputeSha256Hash(model.Password);

             var dbUser =  data.Users.FirstOrDefaultAsync(x => x.HashPassword == hashedPassword && x.Email == model.Email).Result;

            if(dbUser != null)
            {
                return Task.Run(() =>model);
            }

            return null;
        }
    }
}
