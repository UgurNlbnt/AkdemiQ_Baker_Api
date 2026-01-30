using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BakerWebUI.ViewComponents
{
    public class _DefaultStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = client.GetAsync("https://localhost:7109/api/Products/CountProduct");
            var jsonData1 = await response.Result.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData1;

            var response2 = client.GetAsync("https://localhost:7109/api/Chef/CountChef");
            var jsonData2 = await response2.Result.Content.ReadAsStringAsync();
            ViewBag.ChefCount = jsonData2;
            return View();
        }
    }
}
