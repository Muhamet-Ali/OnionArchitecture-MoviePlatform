using Humanizer;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.DTOs.PurchaseDtos;
using Newtonsoft.Json;
using NuGet.Common;
using System.Net.Http.Headers;
using System.Text;

namespace MovieApi.WebUI.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PurchaseController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePurchase(CreatePurchaseDto dto)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            
          
            dto.UserId = HttpContext.Session.GetString("UserId");

            var JsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var message = await client.PostAsync("Userpurchase", content);
            if (message.IsSuccessStatusCode)
            {
                return View();
            }
            var error = await message.Content.ReadAsStringAsync();
            ViewBag.Error = error;
            return RedirectToAction("HomePage", "HomePage");
        }
        [HttpGet]
        public async Task<IActionResult> MyProgramList(string Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var response = await client.GetAsync("Userpurchase/MyProgram/"+Id);
            if (response.IsSuccessStatusCode)
            {
                var JsonData=await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultPurchaseDto>>(JsonData);
                return View(data);
            }

            return View();
        }




    }
}
