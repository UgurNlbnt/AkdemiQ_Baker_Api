using BakerWebUI.Dtos.AdressInfoDto;
using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.Controllers
{
    public class AdminAddressInfoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminAddressInfoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7109/api/AddressInfo/GetAll");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<List<ResultAdressInfoDto>>(jsonData);

                return View(values);
            }

            return View(new List<ResultAdressInfoDto>());
        }

        [HttpGet]
        public IActionResult CreateAddressInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddressInfo(CreateAdressInfoDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync(
                "https://localhost:7109/api/AddressInfo", dto);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAddressInfo(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(
                $"https://localhost:7109/api/AddressInfo/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<UpdateAdressInfoDto>(jsonData);

                return View(value);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAddressInfo(UpdateAdressInfoDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PutAsJsonAsync(
                "https://localhost:7109/api/AddressInfo", dto);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        public async Task<IActionResult> DeleteAddressInfo(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync(
                $"https://localhost:7109/api/AddressInfo?id={id}");

            return RedirectToAction("Index");
        }
    }
}
