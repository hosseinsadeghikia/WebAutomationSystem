using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAutomationSystem.ApplicationCore.Common.ExtensionMethods;
using WebAutomationSystem.ApplicationCore.Common.Security;
using WebAutomationSystem.ApplicationCore.DTOs;
using WebAutomationSystem.ApplicationCore.DTOs.Users;
using WebAutomationSystem.ApplicationCore.Entities;
using WebAutomationSystem.Infrastructure.Repositories;
using WebAutomationSystem.Infrastructure.Repositories.Generic;

namespace WebAutomationSystem.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserManagerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ApplicationUsers> _userRepository;
        private readonly UserManager<ApplicationUsers> _userManager;
        public UserManagerController(IGenericRepository<ApplicationUsers> userRepository,
            UserManager<ApplicationUsers> userManager, IMapper mapper)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _userRepository.All();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(AddUsersDto model)
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

            var user = _mapper.Map<ApplicationUsers>(model);
            user.ImageUrl = fileName;
            user.SignatureUrl = fileName;
            user.RegisterDate = DateTime.Now;
            user.IsActive = 1;

            var res = await _userManager.CreateAsync(user, model.Password);

            if (res.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("ErrorView", "Home");
            }
        }

        [HttpGet]
        public IActionResult EditUser(int userId)
        {
            if (userId == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }

            var user = _userRepository.Get(userId);

            var userMapped = _mapper.Map<EditUsersDto>(user);
            userMapped.CurrentImgName = user.ImageUrl;

            return View(userMapped);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUsersDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var fileName = TempData["currentImgName"].ToString();

            if (model.ImageUrl != null)
            {
                if (ImageSecurity.ImageValidator(model.ImageUrl))
                {
                    fileName.DeleteImage("wwwroot/upload/userImage");
                    model.ImageUrl.UploadImage(fileName, "wwwroot/upload/userImage");
                }
                else
                {
                    ModelState.AddModelError("ImageUrl", "لطفا یک فایل درست انتخاب کنید.");
                    return View(model);
                }
            }

            if (model.SignatureUrl != null)     
            {
                if (ImageSecurity.ImageValidator(model.SignatureUrl))
                {
                    fileName.DeleteImage("wwwroot/upload/signatureImage");
                    model.SignatureUrl.UploadImage(fileName, "wwwroot/upload/signatureImage");
                }
                else
                {
                    ModelState.AddModelError("SignatureUrl", "لطفا یک فایل درست انتخاب کنید.");
                    return View(model);
                }
            }

            var userId = TempData["userId"].ToString();

            var user = await _userManager.FindByIdAsync(userId);

            var userMapped = _mapper.Map(model, user);
            userMapped.Id = int.Parse(TempData["userId"].ToString());
            userMapped.ImageUrl = fileName;
            userMapped.SignatureUrl = fileName;

            var res = await _userManager.UpdateAsync(userMapped);
            
            if (res.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("ErrorView", "Home");
            }
        }
    }
}
