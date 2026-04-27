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
            var response = await client.GetAsync("https://localhost:7109/api/Products/CountProduct");
            var jsonData1 = await response.Content.ReadAsStringAsync();
            ViewBag.ProductCount = jsonData1;

            var response2 = await client.GetAsync("https://localhost:7109/api/Chef/CountChef");
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            ViewBag.ChefCount = jsonData2;

            var response3 = await client.GetAsync("https://localhost:7109/api/Category/CountCategory");
            var jsonData3 = await response3.Content.ReadAsStringAsync();
            ViewBag.CategoryCount = jsonData3;

            var response4 = await client.GetAsync("https://localhost:7109/api/Testimonial/CountTestimonial");
            var jsonData4 = await response4.Content.ReadAsStringAsync();
            ViewBag.TestimonialCount = jsonData4;

            return View();
        }
    }
}
