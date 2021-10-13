using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class Article:Base
    {
        [Required]
        public string Title { get; set; }
       
        public string Authors { get; set; }
        
        public string Content { get; set; }
    }
}
