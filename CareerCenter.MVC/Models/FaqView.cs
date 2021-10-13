using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class FaqView : BaseView
    {
        [Required]
        [DisplayName("Категория")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Зaголовок")]
        public string Title { get; set; }

        [DisplayName("Описания")]
        public string Description { get; set; }

        [DisplayName("Время публикации")]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        public virtual FaqCategoryView FaqCategory { get; set; }
    }
}
