using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class VacancyCategoryView:BaseView
    {
        [DisplayName("Названия")]
        public string Title { get; set; }
    }
}
