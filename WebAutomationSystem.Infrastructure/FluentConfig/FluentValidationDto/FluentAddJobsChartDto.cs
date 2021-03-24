using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using WebAutomationSystem.ApplicationCore.DTOs.JobsChart;

namespace WebAutomationSystem.Infrastructure.FluentConfig.FluentValidationDto
{
    public class FluentAddJobsChartDto : AbstractValidator<AddJobsChartDto>
    {
        public FluentAddJobsChartDto()
        {
            RuleFor(jc => jc.Name).NotNull()
                .WithMessage("نام شغل را وارد کنید.");
        }
    }
}
