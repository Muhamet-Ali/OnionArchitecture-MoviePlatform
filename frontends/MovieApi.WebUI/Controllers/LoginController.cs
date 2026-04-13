using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto.DTOs.LoginDtos;
using Newtonsoft.Json;
using System.Text;
namespace MovieApi.WebUI.Controllers
{
    public class LoginController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult SignIn(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(ReultLoginDto dto,string returnUrl)
        {
            var client = _httpClientFactory.CreateClient("MovieApi");
            var JsonDat = JsonConvert.SerializeObject(dto);
            var content = new StringContent(JsonDat, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("Auth/Login", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadFromJsonAsync<LoginResponseDto>();

                if (data == null)
                {
                    ModelState.AddModelError("", "Login response error");
                    return View(dto);
                }
                // TOKEN'I SESSION'A KOY
               HttpContext.Session.SetString("AccessToken", data.AccessToken??"");
               HttpContext.Session.SetString("UserName", data.UserName ?? "");
               HttpContext.Session.SetString("UserId", data.UserId ?? "");
               HttpContext.Session.SetString("Email", data.Email ?? "");

                // 🔥 BURASI ÖNEMLİ
                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("HomePage", "HomePage");
            }

            ModelState.AddModelError("", "Login failed");
            return View(dto);
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear(); // tüm session temizlenir
            return RedirectToAction("MovieList", "Movie");
        }


    }
}
