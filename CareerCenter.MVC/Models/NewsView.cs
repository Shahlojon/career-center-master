using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class NewsView:BaseView
    {
        [DisplayName("Заголовок")]
        public string Title { get; set; }
        [DisplayName("Фото")]
        public string Image { get; set; }
        [DisplayName("Файл Фото")]
        public IFormFile ImageFile { get; set; }
        [DisplayName("Контент")]
        public string Content { get; set; }
        [DisplayName("Просмотрено")]
        public string Viewed { get; set; }
        [DisplayName("Время публикации")]
        public DateTime PublishedAt { get; set; }
    }
}
