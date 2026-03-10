using BakerWebUI.Dtos.Subscribe;
using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.Controllers
{
    public class AdminSubscriberController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminSubscriberController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7109/api/Subscribe");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<List<ResultSubscribeDto>>(jsonData);

                return View(values);
            }

            return View(new List<ResultSubscribeDto>());
        }

        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync(
                $"https://localhost:7109/api/Subscribe?id={id}");

            return RedirectToAction("Index");
        }
    }
}
