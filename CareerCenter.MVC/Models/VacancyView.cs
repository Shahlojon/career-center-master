using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class VacancyView:BaseView
    {

        [DisplayName("Названия")]
        public string Title { get; set; }
        [DisplayName("Категория")]
        public int CategoryId { get; set; }
        [DisplayName("Полное описания")]
        public string Description { get; set; }
        [DisplayName("Зарплата")]
        public string Salary { get; set; }
        [DisplayName("Тип занятости")]
        public string TypeEmployment { get; set; }
        public virtual VacancyCategoryView Category { get; set; }
    }
}
