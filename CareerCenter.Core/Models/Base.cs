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
    public abstract class Base
    {
        [Key]
        public int Id { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[DefaultValue(true)]
        public bool IsActive { get; set; } = true;

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[DefaultValue("getdate()")]
        public DateTime CretedAt { get; set; } = DateTime.Now;

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[DefaultValue("getdate()")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
