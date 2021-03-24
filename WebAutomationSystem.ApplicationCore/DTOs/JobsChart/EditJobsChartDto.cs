using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomationSystem.ApplicationCore.DTOs.JobsChart
{
    public class EditJobsChartDto
    {
        public int Id { get; set; }

        [Display(Name = "نام شغل")]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        public int Level { get; set; }
    }
}
