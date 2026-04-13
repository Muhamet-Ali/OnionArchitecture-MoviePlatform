using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Controllers
{
    public class PlayerController : Controller
    {
        public async Task<IActionResult> Watch(int id, int contentType)
        {



            return View();
        }
    }
}
