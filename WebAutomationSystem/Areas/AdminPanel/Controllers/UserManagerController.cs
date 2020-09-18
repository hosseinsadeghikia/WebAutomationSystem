using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAutomationSystem.ApplicationCore.Common.ExtensionMethods;
using WebAutomationSystem.ApplicationCore.Common.Security;
using WebAutomationSystem.ApplicationCore.DTOs;
using WebAutomationSystem.ApplicationCore.Entities;
using WebAutomationSystem.Infrastructure.Repositories;

namespace WebAutomationSystem.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserManagerController : Controller
    {
        private readonly IGenericRepository<ApplicationUsers> _userRepository;
        private readonly UserManager<ApplicationUsers> _userManager;
        public UserManagerController(IGenericRepository<ApplicationUsers> userRepository,
            UserManager<ApplicationUsers> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(UsersDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await _userManager.FindByNameAsync(model.UserName) != null)
            {
                ModelState.AddModelError("UserName", "نام کاربری تکراری است.");
                return View(model);
            }

            var fileName = "";
            if (ImageSecurity.ImageValidator(model.ImageUrl))
            {
                fileName = model.ImageUrl.UploadImage("", "wwwroot/upload/userImage");
            }
            else
            {
                ModelState.AddModelError("ImageUrl", "لطفا یک فایل درست انتخاب کنید.");
                return View(model);
            }

            if (ImageSecurity.ImageValidator(model.SignatureUrl))
            {
                model.SignatureUrl.UploadImage(fileName, "wwwroot/upload/signatureImage");
            }
            else
            {
                ModelState.AddModelError("SignatureUrl", "لطفا یک فایل درست انتخاب کنید.");
                return View(model);
            }

            var user = new ApplicationUsers
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PersonalCode = model.PersonalCode,
                NationalCode = model.NationalCode,
                Email = model.Email,
                UserName = model.UserName,
                Address = model.Address,
                BirthDate = model.BirthDate,
                Gender = model.Gender,
                RegisterDate = DateTime.Now,
                ImageUrl = fileName,
                SignatureUrl = fileName,
                IsActive = 1,
                PhoneNumber = model.PhoneNumber
            };

            var res = await _userManager.CreateAsync(user, model.Password);

            if (res.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
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
