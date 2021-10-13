using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class FacultyView:BaseView
    {
        [DisplayName("Университет")]
        public int UniversityId { get; set; }
        [DisplayName("Названия факультета")]
        public string Title { get; set; }
        [DisplayName("Имя декана")]
        public string NameDekan { get; set; }

        public virtual UniversityView University { get; set; }
    }
}
