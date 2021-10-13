using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class PostCategoryView : BaseView
    {
        [Required]
        [DisplayName("Заголовок")]
        public string Title { get; set; }

        public virtual IEnumerable<PostView> Posts { get; set; }
    }
}
