using BakerWebUI.Dtos.Chefs;
using Microsoft.AspNetCore.Mvc;

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
