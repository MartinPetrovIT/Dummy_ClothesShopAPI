using ClothesShoAPI.Database;
using ClothesShop.Logic.Interfaces.Dress.Models;
using ClothesShop.Logic.Interfaces.Dress.Services;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Dress>> GetAll()
        {
            var a = data.Dress.Select(x => new Dress
            {
                Id = x.Id,
                Name = x.Name,
                Brand = x.Brand,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                Type = x.Type,
                Category = x.Category,
                MadeIn = x.MadeIn,
                Composition = x.Composition,
                Size = x.Size,

            }).ToList();
            return await Task.Run(() => data.Dress.Select(x => new Dress
            {
                Id = x.Id,
                Name = x.Name,
                Brand = x.Brand,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                Type = x.Type,
                Category = x.Category,
                MadeIn = x.MadeIn,
                Composition = x.Composition,
                Size = x.Size,

            }).ToListAsync());
        }

        public Task<Dress> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
