using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Database.Entities
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public Order Order { get; set; }

        public int OrderId { get; set; }
    }
}
