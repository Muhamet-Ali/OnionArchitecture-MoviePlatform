using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.DTOs.AdminMovieDtos;
using MovieApi.Dto.DTOs.MovieAdminDtos;
using MovieApi.Dto.DTOs.AdminSeriesDtos;
using Newtonsoft.Json;
using System.Text;
using MovieApi.Dto.DTOs.CategoryAdminDtos;
using NuGet.Versioning;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SeriesController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public SeriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
      
        public async Task<IActionResult>SeriesList()
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Serieses");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSeriesDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        
        //Create Action
        [HttpGet]
        public async Task<IActionResult >CreateSeries()
        {

            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData=await responseMessage.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultAdminCategoryDto>>(JsonData);
                ViewBag.categories=categories;
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSeries(CreateSeriesDto dto)
        {
            //bag yapmak icin
            var client = _httpClientFactory.CreateClient("MovieApi");
            var JsonDat = JsonConvert.SerializeObject(dto);
            var content = new StringContent(JsonDat, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("Serieses", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SeriesList");
            }
            return View(dto);
        }
       
        //Delete Action
        [HttpGet]
        public async Task<IActionResult> DeleteSeries(int id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.DeleteAsync("Serieses?Id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SeriesList");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSeries(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Categories");
            var responseMessageSeries = await client.GetAsync("Serieses/" + Id);

            if (responseMessage.IsSuccessStatusCode&&responseMessageSeries.IsSuccessStatusCode)
            {
                var JsonData=await responseMessage.Content.ReadAsStringAsync();
                var categories= JsonConvert.DeserializeObject<List<ResultAdminCategoryDto>>(JsonData);
                
                var JsonSeries = await responseMessageSeries.Content.ReadAsStringAsync();
                var Series = JsonConvert.DeserializeObject<UpdateSeriesDto>(JsonSeries);

                ViewBag.categories=categories;
                return View(Series);

            }
            return RedirectToAction("SeriesList");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSeries(UpdateSeriesDto Dto)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var JsonData=JsonConvert.SerializeObject(Dto);
            StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var messageResponse = await client.PutAsync("Serieses", content);

            if (messageResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("SeriesList");
            }

            return View();
        } 

        [HttpGet]
        public async Task<IActionResult> DetailSeries(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Serieses/" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData=await responseMessage.Content.ReadAsStringAsync();
                var Series = JsonConvert.DeserializeObject<ResultSeriesDto>(JsonData);
                return View(Series);
            }

            return RedirectToAction("SeriesList");
        }





    }
}
