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
    public class Announcement : Base
    {
        [Required]
        public string Title { get; set; }

        public int UniversityId { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual AnnouncementCategory Category { get; set; }
        public virtual University University { get; set; }
    }
}
