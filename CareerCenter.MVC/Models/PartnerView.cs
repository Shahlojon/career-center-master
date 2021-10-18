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
    public class PartnerView:BaseView
    {
        [Required]
        [DisplayName("Категория")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Заголовок")]
        public string Title { get; set; }

        [DisplayName("Логотип")]
        public string Logo { get; set; }

        [DisplayName("Описания")]
        public string Description { get; set; }
        [DisplayName("Статус")]
        public bool IsConfirmed { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile FileUpload { get; set; }

        public virtual PartnerCategoryView PartnerCategory { get; set; }
    }
}
