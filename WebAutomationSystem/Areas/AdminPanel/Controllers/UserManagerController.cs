using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAutomationSystem.ApplicationCore.Common.ExtensionMethods;
using WebAutomationSystem.ApplicationCore.Common.Security;
using WebAutomationSystem.ApplicationCore.Entities;
using WebAutomationSystem.Infrastructure.Repositories;

namespace WebAutomationSystem.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserManagerController : Controller
    {
        private readonly IGenericRepository<ApplicationUsers> _userRepository;

        public UserManagerController(IGenericRepository<ApplicationUsers> userRepository)
        {
            _userRepository = userRepository;
        }

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

        public IActionResult UploadImage(IFormFile file, string path)
        {
            var imageName = "";
            if (file != null)
            {
                if (ImageSecurity.ImageValidator(file))
                {
                    imageName = file.UploadImage("", "wwwroot/" + path);
                }
            }
            return Json(new { uploaded = true, url = path + imageName });
        }
    }
}
