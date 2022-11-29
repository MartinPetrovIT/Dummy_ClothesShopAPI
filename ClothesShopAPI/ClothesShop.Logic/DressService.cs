using ClothesShoAPI.Database;
using ClothesShop.Logic.Interfaces.Dress.Models;
using ClothesShop.Logic.Interfaces.Dress.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Logic
{
    public class DressService : IDressService
    {
        private readonly ApplicationDBContext data;

        public DressService(ApplicationDBContext data)
        {
            this.data = data;
        }
        public Task<int> CreateDress(Interfaces.Dress.Models.CreateModel dress)
        {
            try
            {
                data.Dress.AddAsync(new Database.Entities.Dress
                {
                    Name = dress.Name,
                    Brand = dress.Brand,
                    Price = dress.Price,
                    ImageUrl = dress.ImageUrl,
                    Type = dress.Type,
                    Category = dress.Category,
                    MadeIn = dress.MadeIn,
                    Composition = dress.Composition,
                    Size = dress.Size,

                });

               return data.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

   

        public Task<bool> DeleteDress(int dressId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditDress(int dressId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dress>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Dress> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
