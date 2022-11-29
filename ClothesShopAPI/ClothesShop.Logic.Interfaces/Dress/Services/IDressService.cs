using Models= ClothesShop.Logic.Interfaces.Dress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Logic.Interfaces.Dress.Services
{
    public interface IDressService
    {
        public Task<int> CreateDress(Models.CreateModel dress);

        public Task<bool> DeleteDress(int dressId);

        public Task<bool> EditDress(int dressId);

        public Task<List<Models.Dress>> GetAll();

        public Task<Models.Dress> GetById(int id);
    }
}
