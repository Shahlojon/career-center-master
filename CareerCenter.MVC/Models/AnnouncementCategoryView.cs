using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class AnnouncementCategoryView:BaseView
    {
        [DisplayName("Заголовак")]
        public string Title { get; set; }
    }
}
