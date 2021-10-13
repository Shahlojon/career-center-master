using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class RegulationCategory:Base
    {
        [Required]
        public string Title { get; set; }

        public virtual IEnumerable<Regulation> Regulations { get; set; }
    }
}
