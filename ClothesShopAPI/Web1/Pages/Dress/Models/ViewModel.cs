using MyEnums = ClothesShop.Enums.Common;
namespace ClothesShopAPI.Pages.Dress.Models
{
    public class ViewModel
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
    }
}
