using BakerWebUI.Dtos.AdressInfoDto;
using Microsoft.AspNetCore.Mvc;

namespace BakerWebUI.ViewComponents
{
    public class _DefaultFooterComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultFooterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7109/api/AddressInfo");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // Bu seçenek verilerin eşleşmesi için kritik!
                var options = new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var addressInfo = System.Text.Json.JsonSerializer.Deserialize<ResultAdressInfoDto>(jsonData, options);
                return View(addressInfo);
            }
            return View();
        }
    }
}
