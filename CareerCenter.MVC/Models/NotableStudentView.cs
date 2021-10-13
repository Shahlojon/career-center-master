using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class NotableStudentView:BaseView
    {
        [Required]
        [DisplayName("Заголовок")]
        public string Title { get; set; }

        [DisplayName("Фото")]
        public string Image { get; set; }

        [Required]
        [DisplayName("Контент")]
        public string Content { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile FileUpload { get; set; }
    }
}
