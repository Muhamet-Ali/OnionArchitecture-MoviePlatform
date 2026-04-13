using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.DTOs.CastDtos;
using Newtonsoft.Json;

namespace MovieApi.WebUI.Controllers
{
    public class CastController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CastController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> GetCast()
        {
            ViewBag.V1 = "Casts List";
            ViewBag.V2 = "Casts Page";
            ViewBag.V3 = "All Casts";
            var client = _httpClientFactory.CreateClient("MovieApi");
            var message = await client.GetAsync("UserCast");
            if(message.IsSuccessStatusCode)
            {
                var JsonData=await message.Content.ReadAsStringAsync();
                var casts=JsonConvert.DeserializeObject<List<GetCastQueryDto>>(JsonData);
                return View(casts); 
            }
            return View(null);
        }
        [HttpGet]
        public async Task<IActionResult> GetCastDetail (int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var message = await client.GetAsync("UserCast/GetCastById/"+Id);
            if (message.IsSuccessStatusCode)
            {
                var JsonData=await message.Content.ReadAsStringAsync();
                var cast= JsonConvert.DeserializeObject<GetCastByIdQueryDto>(JsonData);
                return View(cast);
            }
            return View(null);
        }

    }
}
