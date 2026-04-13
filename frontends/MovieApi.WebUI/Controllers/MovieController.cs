using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.DTOs.MovieDtos;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MovieApi.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MovieList()
        {
            ViewBag.V1 = "Movie List";
            ViewBag.V2 = "Movie Page";
            ViewBag.V3 = "All Movies";
            //for API http://localhost:5257/api/Movies
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5257/api/Movies");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> MovieDetails(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var userId = HttpContext.Session.GetString("UserId") ?? "guest";
            var responseMessage = await client.GetAsync("UserMovie/GetMovieDetail/"+Id+"/"+userId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var MovieDetail = JsonConvert.DeserializeObject<MovieDetailDto>(JsonData);
                return View(MovieDetail);
            }
            return View();
        }
    }
}