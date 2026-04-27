using BakerWebUI.Dtos.Categories;
using BakerWebUI.Dtos.Chefs;
using BakerWebUI.Dtos.ContactDtos;
using BakerWebUI.Dtos.Products;
using BakerWebUI.Dtos.Subscribe;

namespace BakerWebUI.Models
{
    public class DashboardViewModel
    {
        public int ProductCount { get; set; }
        public int CategoryCount { get; set; }
        public int ChefCount { get; set; }
        public int MessageCount { get; set; }
        public int SubscriberCount { get; set; }
        public decimal AverageProductPrice { get; set; }
        public List<ProductWithCategoryDto> Products { get; set; } = new();
        public List<ProductWithCategoryDto> RecentProducts { get; set; } = new();
        public List<ResultContactDto> RecentMessages { get; set; } = new();
        public List<ResultCategoryDto> Categories { get; set; } = new();
        public List<ResultChefDto> Chefs { get; set; } = new();
        public List<ResultSubscribeDto> Subscribers { get; set; } = new();
    }
}
