using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class Vacancy:Base
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public int UniversityId { get; set; }
        public string Description { get; set; }
        public string Salary { get; set; }
        public string TypeEmployment { get; set; }

        public virtual VacancyCategory Category { get; set; }
        public virtual University University { get; set; }
    }
}
