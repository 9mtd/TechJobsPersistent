using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }


        //PART 3: update the AddJobViewModel object so that you pass all of the Skill objects in the database to the constructor.
        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            var employersList = context.Employers.Select(s => new SelectListItem()
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).ToList();

            var skillsList = context.Skills.ToList();

            AddJobViewModel addJobViewModel = new AddJobViewModel(employersList, skillsList);
            
            return View(addJobViewModel);
        }


        //PART 2: Adding a Job - 4. take in an instance of AddJobViewModel and make sure that
        //any validation conditions you want to add are met before creating a new Job object and saving it to the database.
        //PART 3: pass in a new parameter: an array of strings called selectedSkills.
        //When we allow the user to select multiple checkboxes, the user’s selections are stored in a string array. 
        [HttpPost]
        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, List<int> selectedSkills)
        {
            if (ModelState.IsValid)
            {
                Job newJob = new Job
                {
                    Name = addJobViewModel.Name,
                    EmployerId = addJobViewModel.EmployerId
                };

                context.Jobs.Add(newJob);

                if (selectedSkills != null && selectedSkills.Any())
                {
                    //AddRange() method adds the entire collection of elements in the list
                    context.JobSkills.AddRange(selectedSkills.Select(skillId => new JobSkill { SkillId = skillId, Job = newJob }));
                }

                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("AddJob", addJobViewModel);
        }



        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
