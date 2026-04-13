using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.DTOs.AdminEpisodeDtos;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Text;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EpisodeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EpisodeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //Episode Action
        [HttpGet]
        public async Task<IActionResult> EpisodeList()
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Episode");
            if(responseMessage.IsSuccessStatusCode)
            {
                var JsonData=await responseMessage.Content.ReadAsStringAsync();
                var Episodes=JsonConvert.DeserializeObject<List<ResultAdminEpisodeDto>>(JsonData);
                return View(Episodes);
            }
             
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetEpisodesBySeason(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Episode/GetSezonEpisode/" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var Episodes = JsonConvert.DeserializeObject<List<ResultAdminSezoanByEpisodeDto>>(JsonData);
                ViewBag.SeasonName = Episodes.FirstOrDefault()?.SeasonName;

                return View(Episodes);
            }
            return View();
        }


        //Create Action
        [HttpGet]
        public async Task<IActionResult> CreateEpisode(int Id)
        {
            var model = new CreateAdminEpisodeDto();
            model.SeasonId = Id;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEpisode(CreateAdminEpisodeDto dto)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");         
            var JsonData=JsonConvert.SerializeObject(dto);
            var content = new StringContent(JsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("Episode", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("EpisodeList");
            }

            return View(dto);
        }

        //Update Episode
        [HttpGet]
        public async Task<IActionResult> UpdateEpisode(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Episode/" + Id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var Episode = JsonConvert.DeserializeObject<UpdateAdminEpisodeDto>(JsonData);
                return View(Episode);
            }
            return RedirectToAction("EpisodeList");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEpisode(UpdateAdminEpisodeDto dto)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var JsonData = JsonConvert.SerializeObject(dto);
            var content=new  StringContent(JsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("Episode", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("EpisodeList");
            }
            return View(dto);
        }

        //Delete Episode
        public async Task<IActionResult> DeleteEpisode(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.DeleteAsync("Episode/" + Id);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("EpisodeList");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DetailEpisode(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Episode/"+Id);
            if (responseMessage.IsSuccessStatusCode)
            {
               var JsonData= await responseMessage.Content.ReadAsStringAsync();
                var Value=JsonConvert.DeserializeObject<ResultAdminEpisodeDto>(JsonData);
                return View(Value);
            }

            return RedirectToAction("EpisodeList");
        }
        [HttpGet]
        public async Task<IActionResult> ShowEpisode(int Id)
        {
            return View();
        }





    }
}
