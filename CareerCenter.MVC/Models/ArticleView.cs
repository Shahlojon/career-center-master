using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class ArticleView:BaseView
    {
        [Required]
        [DisplayName("Заголовок")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Авторы")]
        public string Authors { get; set; }
        [Required]
        [DisplayName("Контент")]
        public string Content { get; set; }
    }
}
