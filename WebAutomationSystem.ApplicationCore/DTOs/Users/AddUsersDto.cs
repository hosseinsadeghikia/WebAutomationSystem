using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Http;

namespace WebAutomationSystem.ApplicationCore.DTOs.Users
{
    public class AddUsersDto
    {
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Display(Name = "کد پرسنلی")]
        public string PersonalCode { get; set; }

        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "تاریخ تولد")]
        public string BirthDate { get; set; }

        [Display(Name = "جنسیت")]
        public byte Gender { get; set; }

        [Display(Name = "تصویر")]
        public IFormFile ImageUrl { get; set; }

        [Display(Name = "امضا")]
        public IFormFile SignatureUrl { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "موبایل")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        public string ConfirmPassword { get; set; }
    }
}
