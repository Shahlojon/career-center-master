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
    public class ServiceView:BaseView
    {
        [Required]
        [DisplayName("Заголовок")]
        public string Title { get; set; }

        [DisplayName("Описания")]
        public string Description { get; set; }

        [DisplayName("Фото")]
        public string Image { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile FileUpload { get; set; }

    }
}
