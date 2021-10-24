using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        public string Name { get; set; }
        public List<SelectListItem> Employers { get; set; }
        public int EmployerId { get; set; }

    }
}
