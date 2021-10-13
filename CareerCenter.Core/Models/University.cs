using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class University : Base
    {
        public string Name { get; set; }
        public string Faculty { get; set; }//тут я факультет добавила то есть факультеты этого универа 
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Director { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public DateTime CreateDateU { get; set; }
        public string Site { get; set; }
        public string CountStudent { get; set; }
        public string CountStudentGraduates { get; set; }

        public virtual IEnumerable<Faculty> Faculties { get; set; }

    }
}
