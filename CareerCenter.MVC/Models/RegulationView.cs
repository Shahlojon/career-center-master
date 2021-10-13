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
    public class RegulationView:BaseView
    {
        [Required]
        [DisplayName("Заголовок")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Категория")]
        public int CategoryId { get; set; }
        [DisplayName("Файл")]
        public string File { get; set; }

        [DisplayName("Контент")]
        public string Content { get; set; }

        [NotMapped]
        [DisplayName("Файл")]
        public IFormFile FileUpload { get; set; }

        public RegulationCategoryView RegulationCategoryView { get; set; }
    }
}
