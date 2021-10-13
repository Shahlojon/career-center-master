using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class RoleView : IdentityRole<int>
    {
        //public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}
