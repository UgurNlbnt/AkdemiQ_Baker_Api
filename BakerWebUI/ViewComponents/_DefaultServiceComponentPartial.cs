using BakerWebUI.Dtos.Service;
using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.ViewComponents
{
    public class _DefaultServiceComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClient;

        public _DefaultServiceComponentPartial(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public IViewComponentResult Invoke()
        {
            var client = _httpClient.CreateClient();
            var responseMessage = client.GetAsync("https://localhost:7109/api/Service/with_Details").Result;
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = responseMessage.Content.ReadAsStringAsync().Result;
                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
