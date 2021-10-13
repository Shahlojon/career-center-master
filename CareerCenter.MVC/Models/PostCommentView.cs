using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class PostCommentView:BaseView
    {

        [Required]
        [DisplayName("Пользователь")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Заголовок")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Контент")]
        public string Content { get; set; }

        public virtual PostView Post { get; set; }
    }
}
