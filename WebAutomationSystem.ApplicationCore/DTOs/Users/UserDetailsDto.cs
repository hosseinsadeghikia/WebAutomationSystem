using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomationSystem.ApplicationCore.DTOs.Users
{
    public class UserDetailsDto
    {
        public int Id { get; set; }

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
        public string ImageUrl { get; set; }

        [Display(Name = "امضا")]
        public string SignatureUrl { get; set; }

        [Display(Name = "وضعیت")]
        public byte IsActive { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "موبایل")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }
    }
}
