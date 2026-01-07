using BakerWebUI.Dtos.Chefs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BakerWebUI.Controllers
{
    public class ChefController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ChefController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ChefList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/Chef");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultChefDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
//json -> text  buna deserialize denir

//text -> json buna serialize denir