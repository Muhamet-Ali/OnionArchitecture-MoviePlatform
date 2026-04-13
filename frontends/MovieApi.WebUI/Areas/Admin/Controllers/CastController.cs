using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.DTOs.AdminCastDtos;
using MovieApi.Dto.DTOs.AdminMovieDtos;
using MovieApi.Dto.DTOs.AdminSeriesDtos;
using MovieApi.Dto.DTOs.CategoryAdminDtos;
using MovieApi.Dto.DTOs.MovieAdminDtos;
using Newtonsoft.Json;
using System.Text;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CastController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CastController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //Get Lists
        public async Task<IActionResult> CastsList()
        {
            //for API http://localhost:5257/api/Casts
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Casts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAdminCastDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CastMovieList(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("MovieCast/GetMovieCast/" + Id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var JsonData= await responseMessage.Content.ReadAsStringAsync();
                var Values=JsonConvert.DeserializeObject<List<ResultAdminMovieCastDto>>(JsonData);
                return View(Values);
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }
        [HttpGet]
        public async Task<IActionResult> CastSeriesList(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("SeriesCast/GetSeriesCast/" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var Values = JsonConvert.DeserializeObject<List<ResultAdminSeriesCastDto>>(JsonData);
                return View(Values);
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }




        //Create Action 
        [HttpGet]
        public async Task<IActionResult> CreateCast()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCast(CreateAdminCastDto dto)
        {
            //bag yapmak icin
            var client = _httpClientFactory.CreateClient("MovieApi");
            var JsonDat = JsonConvert.SerializeObject(dto);
            var content = new StringContent(JsonDat, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("Casts", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CastsList");
            }
            return View(dto);
        }
     
        [HttpGet]
        public async Task<IActionResult> DeleteCast(int id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");

            var responseMessage = await client.DeleteAsync("Casts/" + id);
            var errorContent = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CastsList");
            }

            return Content($"Status: {(int)responseMessage.StatusCode} - {errorContent}");
        }

        //Update action
        [HttpGet]
        public async Task<IActionResult> UpdateCast(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");

            var responseMessage = await client.GetAsync("Casts/" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAdminCastDto>(JsonData);
               
                return View(value);
            }
            return RedirectToAction("CreateCast");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCast(UpdateAdminCastDto dto)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var JsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var messageResponse = await client.PutAsync("Casts", content);
            if (messageResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("CastsList");
            }

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> DetailCast(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Casts/" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var Cast = JsonConvert.DeserializeObject<ResultAdminCastDto>(JsonData);
                return View(Cast);
            }
            return RedirectToAction("CastsList");
        }

       
   
    }
}
