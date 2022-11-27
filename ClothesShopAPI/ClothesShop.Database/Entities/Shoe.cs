using MyEnums=ClothesShop.Database.Enums;
using System;

namespace ClothesShop.Database.Entities
{
    public class Shoe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public MyEnums.Type Type { get; set; }
        public string MadeIn { get; set; }
        public string Composition { get; set; }
        public int Size { get; set; }
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}
