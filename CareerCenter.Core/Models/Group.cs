using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class Group:Base
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string View { get; set; }
        public string GraduationDepartment { get; set; }//выпуск кафедры это точно не знаю тип
        public int FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}
