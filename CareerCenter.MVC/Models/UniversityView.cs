using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class UniversityView : BaseView
    {
        public string Name { get; set; }
        public string Faculty { get; set; }
        public string Phone { get; set; }
        public string Director { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Image { get; set; }
        [DisplayName("Фото")]
        public IFormFile FileUpload { get; set; }
        public DateTime CreateDateU { get; set; }
        public string Site { get; set; }
        public string CountStudent { get; set; }
        public string CountStudentGraduates { get; set; }

        public virtual IEnumerable<FacultyView> Faculties { get; set; }
    }
}
