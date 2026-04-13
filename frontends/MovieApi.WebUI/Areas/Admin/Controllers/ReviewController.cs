using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.DTOs.AdminReviewDtos;
using MovieApi.Dto.DTOs.AdminReviewDtos.AdminReviewProgramByIdDtos;
using MovieApi.Dto.DTOs.AdminReviewDtos.AdminReviewProgramDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReviewController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReviewController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //Get All Review
        public async Task<IActionResult> ListReviews()
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Review");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData=await responseMessage.Content.ReadAsStringAsync();
                var reviews=JsonConvert.DeserializeObject<List<ResultAdminReviewDto>>(JsonData);
                return View(reviews);
            }

            return View();
        }
        //get all review of Movie
        public async Task<IActionResult> ListMovieReviews()
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Review/GetReviewMovie");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData= await responseMessage.Content.ReadAsStringAsync();
                var reviews=JsonConvert.DeserializeObject<List<ResultReviewMovieAdminDto>>(JsonData);
                return View(reviews);
            }
            return View();
        }
        //get all review of Series
        public async Task<IActionResult> ListSeriesReviews()
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Review/GetReviewSeries");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var reviews = JsonConvert.DeserializeObject<List<ResultReviewSeriesAdminDto>>(JsonData);
                return View(reviews);
            }
            return View();
        }
        //get all review of Episode
        public async Task<IActionResult> ListEpisodeReviews()
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Review/GetReviewEpisode");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var reviews = JsonConvert.DeserializeObject<List<ResultReviewEpisodeAdminDto>>(JsonData);
                return View(reviews);
            }
            return View();
        }

        //get review bu Id detail page
        public async Task<IActionResult> DetailReview(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Review/" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var review= JsonConvert.DeserializeObject<ResultAdminReviewByIdDto>(jsonData);
                return View(review);
            }
            return RedirectToAction("ListReviews");
        }

        
        //Get movie review By Id "GetReviewMovieById/{Id}"
        public async Task<IActionResult> GetMovieReviewById(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Review/GetReviewMovieById/" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData= await responseMessage.Content.ReadAsStringAsync();
                var reviws=JsonConvert.DeserializeObject<List<ResultReviewMovieByIdAdminDto>>(JsonData);
                return View(reviws);
            }
            return View();
        }
        //Get series review By Id
        public async Task<IActionResult> GetSeriesReviewById(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var resposeMessage = await client.GetAsync("Review/GetReviewSeriesByIdById/" + Id);
            if (resposeMessage.IsSuccessStatusCode)
            {
                var Jsondata=await resposeMessage.Content.ReadAsStringAsync();
                var reviews = JsonConvert.DeserializeObject<List<ResultReviewSeriesByIdAdminDto>>(Jsondata);
                return View(reviews);
            }
            return View();  
        }
        //Get movie review By Id
        public async Task<IActionResult> GetEpisodeReviewById(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var resposeMessage = await client.GetAsync("Review/GetReviewEpisodeById/" + Id);
            if (resposeMessage.IsSuccessStatusCode)
            {
                var Jsondata = await resposeMessage.Content.ReadAsStringAsync();
                var reviews = JsonConvert.DeserializeObject<List<ResultReviewEpisodeByIdAdminDto>>(Jsondata);
                return View(reviews);
            }
            return View();
        }




    }
}
