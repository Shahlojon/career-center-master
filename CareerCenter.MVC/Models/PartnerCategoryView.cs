using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class PartnerCategoryView:BaseView
    {
        [Required]
        [DisplayName("Названия")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Отображения имени")]
        public string DisplayName { get; set; }

        public virtual IEnumerable<PartnerView> Partners { get; set; }
    }
}
