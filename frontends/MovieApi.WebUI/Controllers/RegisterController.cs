using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.DTOs.RegisterDtos;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MovieApi.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(CreateRegisterDto dto)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var jsonData=JsonConvert.SerializeObject(dto);
            StringContent stringContent=new StringContent(jsonData,System.Text.Encoding.UTF8,"application/json");
            var response = await client.PostAsync("UserRegister", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SignIn", "Login");
            }
            ViewBag.ErrorMessage = "Registration Failed Please Try Again.";
            return View();
        }

    }
}
