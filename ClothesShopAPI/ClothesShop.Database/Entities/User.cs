using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.Database.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string HashPassword { get; set; }
        public List<Order> Orders { get; set; }

    }
}
