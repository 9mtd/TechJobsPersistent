using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        public AddJobViewModel() { }

        public AddJobViewModel(List<SelectListItem> employers, List<Skill> skills)
        {
            Employers = employers;
            Skills = skills;
        }

        [Required]
        public string Name { get; set; }
        public List<SelectListItem> Employers { get; set; }
        public int EmployerId { get; set; }
        public List<Skill> Skills { get; set; }
        //public List<Skill> employers { get; set; }
        //{
        //    Employers = new List<SelectListItem>();

        //    foreach (var employer in employers)
        //    {
        //        Employers.Add(
        //            new SelectListItem
        //            {
        //                Value = employer.Id.ToString(),
        //                Text = employer.Name
        //            }
        //        ); ;
        //    }
        //}



    }
}
