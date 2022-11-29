using MyEnums = ClothesShop.Enums.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Logic.Interfaces.Dress.Models
{
    public class Dress
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public MyEnums.Type Type { get; set; }
        public MyEnums.Category Category { get; set; }
        public string MadeIn { get; set; }
        public string Composition { get; set; }
        public string Size { get; set; }
        //public int ItemId { get; set; }
    }
}
