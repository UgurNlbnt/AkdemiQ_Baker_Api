using BakerWebUI.Dtos.Service;
using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.Controllers
{
    public class AdminServiceDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminServiceDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int serviceId)
        {
            ViewBag.ServiceId = serviceId;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7109/api/ServiceDetail/byServiceId/{serviceId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<List<ServiceDetailDto>>(jsonData);

                return View(values);
            }

            return View(new List<ServiceDetailDto>());
        }

        [HttpGet]
        public IActionResult CreateServiceDetail(int serviceId)
        {
            ViewBag.ServiceId = serviceId;
            return View(new ServiceDetailDto { ServiceId = serviceId });
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceDetail(ServiceDetailDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync(
                "https://localhost:7109/api/ServiceDetail", dto);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index", new { serviceId = dto.ServiceId });

            ViewBag.ServiceId = dto.ServiceId;
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateServiceDetail(int id, int serviceId)
        {
            ViewBag.ServiceId = serviceId;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(
                $"https://localhost:7109/api/ServiceDetail/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<ServiceDetailDto>(jsonData);

                value.ServiceId = serviceId;
                return View(value);
            }

            return RedirectToAction("Index", new { serviceId = serviceId });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateServiceDetail(ServiceDetailDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsJsonAsync(
                "https://localhost:7109/api/ServiceDetail", dto);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index", new { serviceId = dto.ServiceId });

            ViewBag.ServiceId = dto.ServiceId;
            return View(dto);
        }

        public async Task<IActionResult> DeleteServiceDetail(int id, int serviceId)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:7109/api/ServiceDetail/{id}");

            return RedirectToAction("Index", new { serviceId = serviceId });
        }
    }
}
