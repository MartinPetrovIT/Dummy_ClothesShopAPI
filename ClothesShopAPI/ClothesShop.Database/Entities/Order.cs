using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothesShop.Enums.Common;

namespace ClothesShop.Database.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime DateOfOrder { get; set; }

        public OrderStatus Status { get; set; }

        public List<Item> Items { get; set; }

        //public User User { get; set; }

        //public int UserId { get; set; }
        public decimal TotalSum => Items.Sum(x => x.Price);


    }
}
