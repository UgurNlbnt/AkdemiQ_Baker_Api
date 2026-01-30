using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = client.GetAsync("https://localhost:7109/api/Products/CountProduct");
            var jsonData1 = await response.Result.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData1;
            return View();
        }
    }
}
