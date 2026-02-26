using BakerWebUI.Dtos.Categories;
using BakerWebUI.Dtos.Chefs;
using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7109/api/Category");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var chefs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                return View(chefs);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCatergoryDto)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsJsonAsync("https://localhost:7109/api/Category", createCatergoryDto);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createCatergoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7109/api/Category/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var chef = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(chef);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsJsonAsync("https://localhost:7109/api/Category", updateCategoryDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updateCategoryDto);
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7109/api/Category/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
