using BakerWebUI.Dtos.AdressInfoDto;
using BakerWebUI.Dtos.Gallery;
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
            
            // 1. Fetch Address Info
            var addressResponse = await client.GetAsync("https://localhost:7109/api/AddressInfo");
            ResultAdressInfoDto addressInfo = null;

            if (addressResponse.IsSuccessStatusCode)
            {
                var addressJson = await addressResponse.Content.ReadAsStringAsync();
                var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                addressInfo = System.Text.Json.JsonSerializer.Deserialize<ResultAdressInfoDto>(addressJson, options);
            }

            // 2. Fetch Gallery Images
            var galleryResponse = await client.GetAsync("https://localhost:7109/api/Gallery");
            if (galleryResponse.IsSuccessStatusCode)
            {
                var galleryJson = await galleryResponse.Content.ReadAsStringAsync();
                var galleries = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultGalleryDto>>(galleryJson);
                ViewBag.Galleries = galleries;
            }

            return View(addressInfo);
        }
    }
}
