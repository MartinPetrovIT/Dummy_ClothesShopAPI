using ClothesShop.Logic.Interfaces.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Logic.Interfaces.Auth.Services
{
    public interface IAuthService
    {
        public Task<UserModel> AuthenticateUser(UserModel model);
    }
}
