using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Models
{
	public class User : IdentityUser<int>
	{

		public string Role { get; set; }
		public string FullName { get; set; }//Ф.И.О
		public string Address { get; set; }//Адресс
		public int YearOfEnd { get; set; }//Год окончания
		public string Phone { get; set; }//Телефон номер
		public string Bio { get; set; }//автобиография
		public string Image { get; set; }//фото
		public string Position { get; set; }//должность

		//из того файла
		public string Gender { get; set; }//пол
		public DateTime Birthday { get; set; }//дата рождения
		public string Inn { get; set; }//ИНН
		public string SpecialityCode { get; set; }//код специальности
		public string Speciality { get; set; }//ихтитсос
		public string Mail { get; set; }//почта для указания самих
		public string MobilePhone { get; set; }//мобилный телефон
		public string HomePhone { get; set; }//домашный телефон
		public string LevelOfEducation { get; set; }//зинаи тахсил
		public string FormOfEducation { get; set; }//щакли тахсил
		public bool Quote { get; set; }//квота
		public bool GetDiplom { get; set; }//Диплом гирифт?
		public bool GetExcelantDiplom { get; set; }//Дипломи аъло гирифт?
		public bool SendToJob { get; set; }//Ба чои кор фиристода шуд?
		public bool IsEmployed { get; set; }//Бо чои кор таъмин шуд?
		public bool ArrivedToJob { get; set; }//Ба чои кор хозир шуд?
		public string Region { get; set; }//Ноxия(шаxр)

		//Из второго файла
		public string BirthPlace { get; set; }//место рожения
		public string Nationality { get; set; }//миллат
		public string Qualification { get; set; }//Таxсилот оли 
		public string AcademicDegree { get; set; }//Унвони илмї: 
		public string Languages { get; set; }//Кадом забонњои хориљиро медонад 
		public string IsDeptuies { get; set; }//Вакили Маљлиси вакилони халќ њаст ё не 
		public string IsAwarded { get; set; }//Бо мукофотњои давлатї сарфароз гардонида шудааст ё не 
		public string IsSectoralAwarded { get; set; }//Бо мукофотњои соњавї сарфароз гардонида шудааст 
		public string MaritalStatus { get; set; }//Вазъи оилавї  
		public string Note { get; set; }//Кор ва фаъолияти собиќа: 



		//Student
		public string BasisOfLearning { get; set; }//основа обучения
		public int CreditQty { get; set; }// кол задолженностей
		public int? GroupId { get; set; }      //код группы
		public virtual Group Group{get;set;}

		//Teacher
		public int DepartmentId { get; set; }

		public bool IsSuccess { get; set; }



	}
}
