
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class PostComment:Base
    {
        [Required]
        public string UserName { get; set; }

        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public virtual Post Post { get; set; }

    }
}
