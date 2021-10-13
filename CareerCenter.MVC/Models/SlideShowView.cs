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
    public class SlideShowView:BaseView
    {
        [Required]
        [DisplayName("Место показа")]
        public string Location { get; set; }

        [Required]
        [DisplayName("Заголовок")]
        public string Title { get; set; }

        
        [DisplayName("Фото")]
        public string Image { get; set; }

        
        [DisplayName("Короткое описания")]
        public string ShortDescription { get; set; }

        [DisplayName("Описания")]
        public string Description { get; set; }

        [DisplayName("Upload File")]
        public IFormFile FileUpload { get; set; }


    }
}
