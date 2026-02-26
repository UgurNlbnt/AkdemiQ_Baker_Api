using BakerWebUI.Dtos.Chefs;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace BakerWebUI.Controllers
{
    public class AdminChefController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminChefController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7109/api/Chef");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var chefs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultChefDto>>(jsonData);

                return View(chefs);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateChef()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateChef(CreateChefDto createChefDto)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.PostAsJsonAsync("https://localhost:7109/api/Chef", createChefDto);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createChefDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateChef(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7109/api/Chef/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var chef = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateChefDto>(jsonData);
                return View(chef);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateChef(UpdateChefDto updatehefDto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsJsonAsync("https://localhost:7109/api/Chef", updatehefDto);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(updatehefDto);
        }
        public async Task<IActionResult> DeleteChef(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7109/api/Chef/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
