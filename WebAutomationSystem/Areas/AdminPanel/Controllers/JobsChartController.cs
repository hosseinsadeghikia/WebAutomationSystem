using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAutomationSystem.ApplicationCore.DTOs.JobsChart;
using WebAutomationSystem.ApplicationCore.Entities.Jobs;
using WebAutomationSystem.ApplicationCore.Entities.Users;
using WebAutomationSystem.Infrastructure.Repositories.Generic;

namespace WebAutomationSystem.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class JobsChartController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<JobsChart> _userRepository;
        public JobsChartController(IGenericRepository<JobsChart> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var nodes = new List<TreeViewModel>
            {
                new TreeViewModel {id = "1", text = "مدیر عامل", parent = "#"}
            };

            var jobs = _userRepository.All().Where(x=>x.Level != 0);

            foreach (var job in jobs)
            {
                nodes.Add(new TreeViewModel
                {
                    id = job.Id.ToString(),
                    text = job.Name,
                    parent = job.Level.ToString()
                });
            }

            ViewBag.JobsChart = JsonConvert.SerializeObject(nodes);
            return View();
        }


        [HttpGet]
        public IActionResult AddJobsChart(int id, string selectedNodeName)
        {
            ViewBag.ParentName = selectedNodeName;
            ViewBag.Level = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddJobsChart(AddJobsChartDto addJobsChartDto)
        {
            if (ModelState.IsValid)
            {
                var jobsChart = _mapper.Map<JobsChart>(addJobsChartDto);
                _userRepository.Add(jobsChart);
                _userRepository.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(addJobsChartDto);
        }

        [HttpGet]
        public IActionResult EditJobsChart(int id, string selectedNodeName)
        {
            if (id == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }

            var jobsChart = _userRepository.Get(id);
            if (jobsChart == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }

            var jobsChartMap = _mapper.Map<EditJobsChartDto>(jobsChart);

            return View(jobsChartMap);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditJobsChart(EditJobsChartDto editJobsChartDto)
        {
            if (ModelState.IsValid)
            {
                var jobsChart = _mapper.Map<JobsChart>(editJobsChartDto);
                _userRepository.Update(jobsChart);
                _userRepository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(editJobsChartDto);
        }
    }
}
