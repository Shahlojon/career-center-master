using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class Faculty:Base
    {
        public int UniversityId { get; set; }
        public string Title{get;set;}
        public string NameDekan { get; set; }

        public virtual University University { get; set; }
    }
}
