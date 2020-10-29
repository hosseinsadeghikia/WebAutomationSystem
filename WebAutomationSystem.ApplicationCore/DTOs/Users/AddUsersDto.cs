using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebAutomationSystem.ApplicationCore.DTOs.Users
{
    public class AddUsersDto
    {
        [Display(Name = "نام")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید.")]
        [StringLength(maximumLength: 100, MinimumLength = 2,
            ErrorMessage = "{0} باید حداقل 2 و حداکثر 100 کاراکتر باشد.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$",
            ErrorMessage = "از کاراکترهای غیر مجاز استفاده نکنید.")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید.")]
        [StringLength(maximumLength: 150, MinimumLength = 2,
            ErrorMessage = "{0} باید حداقل 2 و حداکثر 150 کاراکتر باشد.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$",
            ErrorMessage = "از کاراکترهای غیر مجاز استفاده نکنید.")]
        public string LastName { get; set; }


        [Display(Name = "کد پرسنلی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید.")]
        [MinLength(10, ErrorMessage = "{0} باید 10 رقمی باشد.")]
        [MaxLength(10, ErrorMessage = "{0} باید 10 رقمی باشد.")]
        public string PersonalCode { get; set; }

        [Display(Name = "کد ملی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید.")]
        [MinLength(10, ErrorMessage = "{0} باید 10 رقمی باشد.")]
        [MaxLength(10, ErrorMessage = "{0} باید 10 رقمی باشد.")]
        [RegularExpression("^[0-9]*$",
            ErrorMessage = "فرمت {0} صحیح نیست.")]
        public string NationalCode { get; set; }

        [Display(Name = "آدرس")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید.")]
        public string Address { get; set; }

        [Display(Name = "تاریخ تولد")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را انتخاب کنید.")]
        public string BirthDate { get; set; }

        [Display(Name = "جنسیت")]
        public byte Gender { get; set; }

        [Display(Name = "تصویر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را آپلود کنید.")]
        public IFormFile ImageUrl { get; set; }

        [Display(Name = "امضا")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را آپلود کنید.")]
        public IFormFile SignatureUrl { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} نباید بیشتر از {1} باشد.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید.")]
        [EmailAddress(ErrorMessage = "لطفا یک {0} معتبر وارد کنید.")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
            ErrorMessage = "لطفا یک {0} معتبر وارد کنید.")]
        public string Email { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
        [MinLength(11, ErrorMessage = "{0} باید 11 رقمی باشد.")]
        [MaxLength(11, ErrorMessage = "{0} باید 11 رقمی باشد.")]
        [RegularExpression(@"^\(?(09)\)?([0-9]{9})$", ErrorMessage = "لطفا یک {0} معتبر وارد کنید.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید.")]
        [StringLength(maximumLength: 50, MinimumLength = 4,
            ErrorMessage = "{0} باید حداقل 2 و حداکثر 50 کاراکتر باشد.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$",
            ErrorMessage = "از کاراکترهای غیر مجاز استفاده نکنید.")]
        public string UserName { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید.")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "{0} باید حداقل 4 و حداکثر 25 کاراکتر باشد.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} را وارد کنید.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "{0} با رمز عبور همخوانی ندارد.")]
        public string ConfirmPassword { get; set; }
    }


    public class AddUsersValidator
    {

    }

}
