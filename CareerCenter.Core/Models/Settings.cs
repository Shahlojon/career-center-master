using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class Settings:Base
    {
        [Required]
        public string Key { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}
