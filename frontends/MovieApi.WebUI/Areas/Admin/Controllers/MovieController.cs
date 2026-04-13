using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.DTOs.AdminMovieDtos;
using MovieApi.Dto.DTOs.CategoryAdminDtos;
using MovieApi.Dto.DTOs.MovieAdminDtos;
using Newtonsoft.Json;
using NuGet.Versioning;
using System.Text;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> MoviesList()
        {
            //for API http://localhost:5257/api/Movies
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Movies");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAdminMovieDto>>(jsonData);
                return View(values);
            }
            return View();
         }
         
        //Create Action 
        [HttpGet]
        public async Task<IActionResult >CreateMovie()
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Categories");
            if(responseMessage.IsSuccessStatusCode)
            {
                var data=await responseMessage.Content.ReadAsStringAsync();
                var Categories= JsonConvert.DeserializeObject<List<ResultAdminCategoryDto>>(data);
                ViewBag.Categories = Categories;    
            }
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(AdminCreateMovieDto dto)
        {
            //bag yapmak icin
            var client = _httpClientFactory.CreateClient("MovieApi");
            var JsonDat = JsonConvert.SerializeObject(dto);
            var content = new StringContent(JsonDat, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("Movies", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MoviesList");
            }
              return View(dto);
        }
        
        //remove action
        [HttpGet]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");

            var responseMessage =await client.DeleteAsync("Movies?Id="+ id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MoviesList");
            }

            return View();
        }

        //Update action
        [HttpGet]
        public async Task<IActionResult> UpdateMovie(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");

            var responseMessage = await client.GetAsync("Movies/" + Id);
            var responseMessageCategory = await client.GetAsync("Categories");
            if (responseMessage.IsSuccessStatusCode && responseMessageCategory.IsSuccessStatusCode)
            {
                var JsonData =await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateMovieAdminDto>(JsonData);

                var JsonDataCategory= await responseMessageCategory.Content.ReadAsStringAsync();
                var categories=JsonConvert.DeserializeObject<List<ResultAdminCategoryDto>>(JsonDataCategory);
                ViewBag.categories = categories;
                return View(value);
            }
            return RedirectToAction("CreateMovie");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMovie(UpdateMovieAdminDto dto)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var JsonData =JsonConvert.SerializeObject(dto);
            StringContent content=new StringContent(JsonData, Encoding.UTF8, "application/json");
            var messageResponse = await client.PutAsync("Movies", content);
            if (messageResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("MoviesList");
            }

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> DetailMovie(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Movies/" + Id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var JsonData=await responseMessage.Content.ReadAsStringAsync();
                var Movie=JsonConvert.DeserializeObject<ResultAdminMovieDto>(JsonData);
                return View(Movie);
            }
            return RedirectToAction("MoviesList");
        }

    }
}
