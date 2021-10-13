using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class GalleryView:BaseView
    {
        [DisplayName("Заголовок")]
        public string Title { get; set; }

        [DisplayName("Файл")]
        public string File { get; set; }
        
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile FileUpload { get; set; }
    
    }
}
