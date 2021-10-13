using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class PostView : BaseView
    {
        [Required]
        [DisplayName("Категория")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Заголовок")]
        public string Title { get; set; }

        
        [DisplayName("Фото")]
        public string Image { get; set; }

        [DisplayName("Контент")]
        public string Content { get; set; }


        [DisplayName("Файл")]
        public string File { get; set; }


        /// <summary>
        /// Нужна подумать так правильно или нет
        /// </summary>
        [DisplayName("Фото")]
        public IFormFile ImageFile { get; set; }
        
        [DisplayName("Файл")]
        public IFormFile IFile { get; set; }

        public virtual PostCategoryView PostCategory { get; set; }
        public virtual IEnumerable<PostCommentView> PostComments { get; set; }
    }
}
