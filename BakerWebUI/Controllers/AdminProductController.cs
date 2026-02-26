using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BakerWebUI.Dtos.Products;

namespace BakerWebUI.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public AdminProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/Products/with_category");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<BakerWebUI.Dtos.Categories.ResultCategoryDto>>(jsonData);
                
                List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> categoryValues = (from x in values
                                                                                            select new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                                                                                            {
                                                                                                Text = x.CategoryName,
                                                                                                Value = x.CategoryId.ToString()
                                                                                            }).ToList();
                ViewBag.v = categoryValues;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PostAsJsonAsync("https://localhost:7109/api/Products", createProductDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createProductDto);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7109/api/Products/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // Sınıf listesini getir
            var responseMessage1 = await client.GetAsync("https://localhost:7109/api/Category");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<List<BakerWebUI.Dtos.Categories.ResultCategoryDto>>(jsonData1);
                List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> categoryValues = (from x in values1
                                                                                            select new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                                                                                            {
                                                                                                Text = x.CategoryName,
                                                                                                Value = x.CategoryId.ToString()
                                                                                            }).ToList();
                ViewBag.v = categoryValues;
            }

            // Güncellenecek ürünün bilgilerini getir
            var responseMessage = await client.GetAsync($"https://localhost:7109/api/Products/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PutAsJsonAsync("https://localhost:7109/api/Products", updateProductDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updateProductDto);
        }
    }
}
