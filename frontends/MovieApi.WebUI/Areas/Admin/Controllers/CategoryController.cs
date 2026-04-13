using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.DTOs.AdminMovieDtos;
using MovieApi.Dto.DTOs.CategoryAdminDtos;
using Newtonsoft.Json;
using System.Text;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public  async Task<IActionResult> CategoryList()
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAdminCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public  IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateAdminCategoryDto dto)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var JsonData=JsonConvert.SerializeObject(dto);
            StringContent content= new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("Categories",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var reponseMessage = await client.DeleteAsync("Categories?Id=" + id);
            if(reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }

            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int Id)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var responseMessage = await client.GetAsync("Categories/" + Id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateAdminCategoryDto>(JsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateAdminCategoryDto dto)
        {
            var client= _httpClientFactory.CreateClient("MovieApi");
            //http://localhost:5257/api/Categories
            var JaonData=JsonConvert.SerializeObject(dto);  
            StringContent content=new StringContent(JaonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("Categories", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");

            }
            return View(dto);
        }

    }
}
