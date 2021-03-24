using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using WebAutomationSystem.ApplicationCore.DTOs.JobsChart;

namespace WebAutomationSystem.Infrastructure.FluentConfig.FluentValidationDto
{
    public class FluentEditJobsChartDto : AbstractValidator<EditJobsChartDto>
    {
        public FluentEditJobsChartDto()
        {
            RuleFor(jc => jc.Name).NotNull()
                .WithMessage("نام شغل را وارد کنید.");
        }
    }
}
