using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAutomationSystem.ApplicationCore.Common.ExtensionMethods;
using WebAutomationSystem.ApplicationCore.Common.Security;

namespace WebAutomationSystem.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserManagerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        public IActionResult UploadImage(IFormFile imageUrl)
        {
            var imageName = "";
            if (imageUrl != null) // یعنی عکس تغییر داده شده بود
            {
                if (ImageSecurity.ImageValidator(imageUrl))
                {
                    imageName = imageUrl.UploadImage("", "wwwroot/upload/userImage");
                }
            }
            return Json(new { uploaded = true, url = "/upload/userImage/" + imageName });
        }
    }
}
