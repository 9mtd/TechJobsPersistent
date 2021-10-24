using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        //Part 2: CONTROLLERS - Set up a private DbContext. Pass it into a EmployerController constructor
        private JobDbContext context;
        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
         }


        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> employers = context.Employers.ToList();
            return View(employers);
        }

        public IActionResult Add()
        {
            
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }

        [HttpPost]
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location,
                };

                context.Employers.Add(newEmployer);
                context.SaveChanges();

                return View("/Employer");
            }

            return View(addEmployerViewModel);
        }

        public IActionResult About(int id)
        {
            
            var empl = context.Employers.SingleOrDefault(s => s.Id == id);
            return View(empl);
        }
    }
}
