using BakerWebUI.Dtos.Categories;
using BakerWebUI.Dtos.Chefs;
using BakerWebUI.Dtos.ContactDtos;
using BakerWebUI.Dtos.Products;
using BakerWebUI.Dtos.Subscribe;
using BakerWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BakerWebUI.Controllers
{
    public class DashboardController : Controller
    {
        private const string ApiBaseUrl = "https://localhost:7109/api";
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var products = await GetApiListAsync<ProductWithCategoryDto>(client, "Products/with_category");
            var categories = await GetApiListAsync<ResultCategoryDto>(client, "Category");
            var chefs = await GetApiListAsync<ResultChefDto>(client, "Chef");
            var messages = await GetApiListAsync<ResultContactDto>(client, "Contact");
            var subscribers = await GetApiListAsync<ResultSubscribeDto>(client, "Subscribe");

            var model = new DashboardViewModel
            {
                ProductCount = products.Count,
                CategoryCount = categories.Count,
                ChefCount = chefs.Count,
                MessageCount = messages.Count,
                SubscriberCount = subscribers.Count,
                AverageProductPrice = products.Count > 0 ? products.Average(x => x.ProductPrice) : 0,
                Products = products,
                RecentProducts = products.OrderByDescending(x => x.ProductId).Take(5).ToList(),
                RecentMessages = messages.OrderByDescending(x => x.ContactId).Take(5).ToList(),
                Categories = categories,
                Chefs = chefs,
                Subscribers = subscribers
            };

            return View(model);
        }

        private static async Task<List<T>> GetApiListAsync<T>(HttpClient client, string endpoint)
        {
            try
            {
                var response = await client.GetAsync($"{ApiBaseUrl}/{endpoint}");
                if (!response.IsSuccessStatusCode)
                {
                    return new List<T>();
                }

                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(jsonData) ?? new List<T>();
            }
            catch (HttpRequestException)
            {
                return new List<T>();
            }
        }
    }
}
