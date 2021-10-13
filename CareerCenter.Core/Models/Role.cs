using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class Role: IdentityRole<int>
    {
       //public string Name { get; set; }
       public string DisplayName { get; set; }
    }
}
