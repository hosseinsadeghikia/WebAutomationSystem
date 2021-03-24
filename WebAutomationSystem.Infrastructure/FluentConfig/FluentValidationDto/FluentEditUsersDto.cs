using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FluentValidation.Validators;
using WebAutomationSystem.ApplicationCore.DTOs.Users;

namespace WebAutomationSystem.Infrastructure.FluentConfig.FluentValidationDto
{
    public class FluentEditUsersDto : AbstractValidator<EditUsersDto>
    {
        public FluentEditUsersDto()
        {
            #region FirstName

            RuleFor(user => user.FirstName).NotNull()
                .WithMessage("نام را وارد کنید.");

            RuleFor(user => user.FirstName).MinimumLength(2)
                .WithMessage("نام باید حداقل 2 کاراکتر باشد.");

            RuleFor(user => user.FirstName).MaximumLength(100)
                .WithMessage("نام باید حداکثر 100 کاراکتر باشد.");

            RuleFor(user => user.LastName)
                .SetValidator(new RegularExpressionValidator(@"^[^\\/:*;\.\)\(]+$"))
                .WithMessage("از کاراکترهای غیر مجاز استفاده نکنید.");

            #endregion

            #region LastName

            RuleFor(user => user.LastName).NotNull()
                .WithMessage("نام خانوادگی را وارد کنید.");

            RuleFor(user => user.LastName).MinimumLength(2)
                .WithMessage("نام خانوادگی باید حداقل 2 کاراکتر باشد.");

            RuleFor(user => user.LastName).MaximumLength(100)
                .WithMessage("نام خانوادگی باید حداکثر 150 کاراکتر باشد.");

            RuleFor(user => user.LastName)
                .SetValidator(new RegularExpressionValidator(@"^[^\\/:*;\.\)\(]+$"))
                .WithMessage("از کاراکترهای غیر مجاز استفاده نکنید.");

            #endregion

            #region PersonalCode

            RuleFor(user => user.PersonalCode).NotNull()
                .WithMessage("کد پرسنلی را وارد کنید.");

            RuleFor(user => user.PersonalCode).NotNull().MinimumLength(10)
                .WithMessage("کد پرسنلی باید حداقل 10 کاراکتر باشد.");

            RuleFor(user => user.PersonalCode).MaximumLength(10)
                .WithMessage("کد پرسنلی باید حداکثر 10 کاراکتر باشد.");

            #endregion

            #region NationalCode

            RuleFor(user => user.NationalCode).NotNull()
                .WithMessage("کد ملی را وارد کنید.");

            RuleFor(user => user.NationalCode).MinimumLength(10)
                .WithMessage("کد ملی باید حداقل 10 کاراکتر باشد.");

            RuleFor(user => user.NationalCode).MaximumLength(10)
                .WithMessage("کد ملی باید حداکثر 10 کاراکتر باشد.");

            RuleFor(user => user.NationalCode)
                .SetValidator(new RegularExpressionValidator("^[0-9]*$"))
                .WithMessage("فرمت کد ملی صحیح نیست.");

            #endregion

            #region Address

            RuleFor(user => user.Address).NotNull()
                .WithMessage("آدرس را وارد کنید.");

            #endregion

            #region BirthDate

            RuleFor(user => user.BirthDate).NotNull()
                .WithMessage("تاریخ تولد را انتخاب کنید.");

            #endregion

            #region ImageUrl

            RuleFor(user => user.ImageUrl).NotNull()
                .WithMessage("تصویر را آپلود کنید.");

            #endregion

            #region SignatureUrl

            RuleFor(user => user.SignatureUrl).NotNull()
                .WithMessage("امضا را آپلود کنید.");

            #endregion

            #region Email

            RuleFor(user => user.Email).NotNull()
                .WithMessage("ایمیل را وارد کنید.");

            RuleFor(user => user.Email).MaximumLength(100)
                .WithMessage("ایمیل باید حداکثر 100 کاراکتر باشد.");

            RuleFor(user => user.Email).EmailAddress()
                .WithMessage("لطفا یک ایمیل معتبر وارد کنید");

            RuleFor(user => user.Email)
                .SetValidator(new RegularExpressionValidator(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$"))
                .WithMessage("فرمت ایمیل صحیح نیست.");

            #endregion

            #region PhoneNumber

            RuleFor(user => user.PhoneNumber).NotNull()
                .WithMessage("موبایل را وارد کنید.");

            RuleFor(user => user.PhoneNumber).MaximumLength(11)
                .WithMessage("موبایل باید 11 رقمی باشد.");

            RuleFor(user => user.PhoneNumber).MinimumLength(11)
                .WithMessage("موبایل باید 11 رقمی باشد.");

            RuleFor(user => user.PhoneNumber)
                .SetValidator(new RegularExpressionValidator(@"^\(?(09)\)?([0-9]{9})$"))
                .WithMessage("لطفا یک موبایل معتبر وارد کنید.");

            #endregion
        }
    }
}
