using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class GroupView:BaseView
    {
        [DisplayName("Код группы")]
        public string Code { get; set; }

        [DisplayName("Названия группы")]
        public string Name { get; set; }

        [DisplayName("Вид группы")]
        public string View { get; set; }

        [DisplayName("Выпуск кафедры")]
        public string GraduationDepartment { get; set; }//выпуск кафедры
    }
}
