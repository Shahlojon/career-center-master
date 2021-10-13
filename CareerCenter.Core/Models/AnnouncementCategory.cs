using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class AnnouncementCategory:Base
    {
        public string Title { get; set; }

        public virtual IEnumerable<Announcement> Announcements { get; set; }
    }
}
