using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.DTOs.HomePageDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Controllers
{
    public class HomePageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomePageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> HomePage()
        {
            ViewBag.V1 = "Main List";
            ViewBag.V2 = "main page";
            ViewBag.V3 = "All Movies & Serieses";
            var client =  _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("UserHomePage");
            if(responseMessage.IsSuccessStatusCode)
            {
                var JsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<HomePageDto>>(JsonData);

                return View(values);
            }
            return View();
        }




    }
}
