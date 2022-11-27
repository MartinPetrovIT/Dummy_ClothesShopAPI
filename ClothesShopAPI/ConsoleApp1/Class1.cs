using ClothesShoAPI.Database;
using ClothesShop.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Class1
    {
        ApplicationDBContext dBContext;
        public Class1(ApplicationDBContext dBContext)
        {
              this.dBContext = dBContext;
        }

        public bool Add()
        {
            dBContext.Items.Add(new Item { Brand = "Mercedes", Name = "BMW", Price = 100000 });
            dBContext.SaveChanges();
            return true;
        }

    }
}
