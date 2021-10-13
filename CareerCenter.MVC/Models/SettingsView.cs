using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class SettingsView:BaseView
    {
        [Required]
        [DisplayName("Ключ")]
        public string Key { get; set; }
        
        [Required]
        [DisplayName("Названия")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Значения")]
        public string Value { get; set; }
    }
}
