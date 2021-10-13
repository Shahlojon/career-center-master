
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class ContractView:BaseView
    { 
		[DisplayName("Файл")]
		public string File { get; set; } //файл для уже подписанного договора
		[DisplayName("Номер договора")]
		public int Number { get; set; }// номер договора
		[DisplayName("Конец даты")]
		public DateTime DateEnd { get; set; }
		[DisplayName("ID пользователя")]
		public int UserId { get; set; }
		[DisplayName("ID партнера")]
		public int PartnerId { get; set; }
		[DisplayName("Пасспорт")]
		public string Passport { get; set; }
		[DisplayName("Фото")]
		public string Photo { get; set; }
		[DisplayName("Статус")]
		public int Status { get; set; }
		[DisplayName("Контент")]
		public string Content { get; set; }
		[DisplayName("Лого компании")]
		public string Logo { get; set; }
	}
}
