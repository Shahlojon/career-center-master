using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class FaqCategoryView:BaseView
    {
        [Required]
        [DisplayName("Заголовок")]
        public string Title { get; set; }

        public virtual IEnumerable<FaqView> Faqs { get; set; }
    }
}
