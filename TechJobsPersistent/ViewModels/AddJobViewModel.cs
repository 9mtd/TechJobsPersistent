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


        //PART 3: Add a property for a list of each Skill object in the database.
        //Pass another parameter of a list of Skill objects.
        //Set the List<Skill> property equal to the parameter you have just passed in.
        [Required]
        public string Name { get; set; }
        public List<SelectListItem> Employers { get; set; }
        public int EmployerId { get; set; }
        public List<Skill> Skills { get; set; }



    }
}
