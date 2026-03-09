using BakerWebUI.Dtos.About;
using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.Controllers
{
    public class AdminAboutDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAboutDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int aboutId)
        {
            ViewBag.AboutId = aboutId;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7109/api/AboutDetail/byAboutId/{aboutId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<List<AboutDetailDto>>(jsonData);

                return View(values);
            }

            return View(new List<AboutDetailDto>());
        }

        [HttpGet]
        public IActionResult CreateAboutDetail(int aboutId)
        {
            ViewBag.AboutId = aboutId;
            return View(new AboutDetailDto { AboutId = aboutId });
        }

        [HttpPost]
        public async Task<IActionResult> CreateAboutDetail(AboutDetailDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync(
                "https://localhost:7109/api/AboutDetail", dto);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index", new { aboutId = dto.AboutId });

            ViewBag.AboutId = dto.AboutId;
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAboutDetail(int id, int aboutId)
        {
            ViewBag.AboutId = aboutId;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(
                $"https://localhost:7109/api/AboutDetail/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<AboutDetailDto>(jsonData);

                value.AboutId = aboutId;
                return View(value);
            }

            return RedirectToAction("Index", new { aboutId = aboutId });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAboutDetail(AboutDetailDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsJsonAsync(
                "https://localhost:7109/api/AboutDetail", dto);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index", new { aboutId = dto.AboutId });

            ViewBag.AboutId = dto.AboutId;
            return View(dto);
        }

        public async Task<IActionResult> DeleteAboutDetail(int id, int aboutId)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7109/api/AboutDetail?id={id}");

            return RedirectToAction("Index", new { aboutId = aboutId });
        }
    }
}
