using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.DTOs.AdminSeriesDtos;
using MovieApi.Dto.DTOs.MovieDtos;
using MovieApi.Dto.DTOs.SeriesDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Controllers
{
    public class SeriesController : Controller
    {
        //Serieses

        private readonly IHttpClientFactory _httpClientFactory;

        public SeriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SeriesList()
        {
            ViewBag.V1 = "Movie List";
            ViewBag.V2 = "Series Page";
            ViewBag.V3 = "All Serieses";
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Serieses");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<SeriesDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> SeriesDetails(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var userId = HttpContext.Session.GetString("UserId") ?? "guest";
            var responseMessage = await client.GetAsync("UserSeries/GetSeriesDetail/" + Id + "/" + userId);

            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var SeriesDetail = JsonConvert.DeserializeObject<SeriesDetailDto>(JsonData);
                return View(SeriesDetail);

            }
            return RedirectToAction("SeriesList");
        }
    }
}
