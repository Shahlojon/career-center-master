using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class Post:Base
    {
        [Required]
        public int PostCategoryId { get; set; }

        [Required]
        public string Title { get; set; }


        public string Image { get; set; }

        [Required]
        public string Content { get; set; }


        public string File { get; set; }

        public int UniversityId { get; set; }

        public virtual PostCategory PostCategory { get; set; }
        public virtual IEnumerable<PostComment> PostComments { get; set; }
        public virtual University University { get; set; }

    }
}
