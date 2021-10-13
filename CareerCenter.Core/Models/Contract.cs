
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
    public class Contract:Base
    { 
		public string File { get; set; } //файл для уже подписанного договора
		public int Number { get; set; }// номер договора
		public DateTime DateEnd { get; set; }
		public int UserId { get; set; }
		public int PartnerId { get; set; }
		public string Passport { get; set; }
		public string Photo { get; set; }
		public int Status { get; set; }
		public string Content { get; set; }
		public string Logo { get; set; }
	}
}
