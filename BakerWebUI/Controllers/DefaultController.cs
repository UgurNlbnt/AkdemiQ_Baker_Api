using BakerWebUI.Dtos.Subscribe;
using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(CreateSubscribeDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7109/api/Subscribe", dto);

            if (response.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = "Bültenimize başarıyla abone oldunuz." });
            }

            return Json(new { success = false, message = "Abonelik sırasında bir hata oluştu." });
        }
    }
}
