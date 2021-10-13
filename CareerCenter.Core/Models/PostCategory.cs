using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class PostCategory : Base 
    {
        [Required]
        public string Title { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
