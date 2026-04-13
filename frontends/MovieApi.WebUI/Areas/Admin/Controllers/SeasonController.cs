using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.DTOs.AdminMovieDtos;
using MovieApi.Dto.DTOs.AdminSeriesDtos;
using MovieApi.Dto.DTOs.AdminSeasonDtos;
using Newtonsoft.Json;
using System.Text;

namespace SeasonApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SeasonController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SeasonController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> SeasonsList()
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Season");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAdminSeasonDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        //Create Action  
        [HttpGet]
        public async Task<IActionResult> CreateSeason()
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Movies");
            var responseMessageSeries = await client.GetAsync("Serieses");

            if (responseMessage.IsSuccessStatusCode&& responseMessageSeries.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var dataSerieses = await responseMessageSeries.Content.ReadAsStringAsync();

                var Movies = JsonConvert.DeserializeObject<List<ResultAdminMovieDto>>(data);
                var Serieses= JsonConvert.DeserializeObject<List<ResultSeriesDto>>(dataSerieses);
                ViewBag.Movies = Movies;
                ViewBag.Serieses = Serieses;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeason(CreateAdminSeasonDto dto)
        {
            //bag yapmak icin
            var client = _httpClientFactory.CreateClient("MovieApi");
            var JsonDat = JsonConvert.SerializeObject(dto);
            var content = new StringContent(JsonDat, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("Season", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SeasonsList");
            }
            return View(dto);
        }

        //remove action
        [HttpGet]
        public async Task<IActionResult> DeleteSeason(int id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");

            var responseMessage = await client.DeleteAsync("Season/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SeasonsList");
            }

            return View();
        }

        //Update action
        [HttpGet]
        public async Task<IActionResult> UpdateSeason(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");

            var responseMessage = await client.GetAsync("Season/" + Id);

            var responseMessageMovie = await client.GetAsync("Movies");
            var responseMessageSeries = await client.GetAsync("Serieses");
            if (responseMessage.IsSuccessStatusCode && responseMessageMovie.IsSuccessStatusCode && responseMessageSeries.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAdminSeasonDto>(JsonData);

                var JsonDataMovie = await responseMessageMovie.Content.ReadAsStringAsync();
                var JsonDataSeries = await responseMessageSeries.Content.ReadAsStringAsync();

                var movies = JsonConvert.DeserializeObject<List<ResultAdminSeasonDto>>(JsonDataMovie);
                var Serises = JsonConvert.DeserializeObject<List<ResultAdminSeasonDto>>(JsonDataSeries);
                ViewBag.movies = movies;
                ViewBag.Serises = Serises;
                return View(value);
            }
            return RedirectToAction("SeasonsList");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSeason(UpdateAdminSeasonDto dto)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var JsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var messageResponse = await client.PutAsync("Season", content);
            if (messageResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("SeasonsList");
            }

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> DetailSeason(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Season/" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var Season = JsonConvert.DeserializeObject<ResultAdminSeasonDto>(JsonData);
                return View(Season);
            }
            return RedirectToAction("SeasonsList");
        }


    }
}
