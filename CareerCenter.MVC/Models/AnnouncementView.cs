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
    public class AnnouncementView : BaseView
    {
        [Required]
        [DisplayName("Заголовок")]
        public string Title { get; set; }

        [DisplayName("Фото")]
        public string Image { get; set; }
        [DisplayName("Категория")]
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Описания")]
        public string Description { get; set; }

        [DisplayName("Университет")]
        public int UniversityId { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile FileUpload { get; set; }

        [DisplayName("Категория")]
        public virtual AnnouncementCategoryView Category { get; set; }

        [DisplayName("Университет")]
        public virtual UniversityView University { get; set; }
    }
}
