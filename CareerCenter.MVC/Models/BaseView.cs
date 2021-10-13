using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class BaseView
    {
        [DisplayName("№")]
        public int Id { get; set; }

        [DisplayName("Активность")]
        public bool IsActive { get; set; } = true;

        [DisplayName("Дата создания")]
        public DateTime CretedAt { get; set; } = DateTime.Now;

        [DisplayName("Дата обновления")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
