using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class UserView: IdentityUser<int>
	{
		[DisplayName("Роль")]
		public string Role { get; set; }
		[DisplayName("Ф.И.О")]
		public string FullName { get; set; }//Ф.И.О
		[DisplayName("Адресс")]
		public string Address { get; set; }//Адресс
		[DisplayName("Год окончания")]
		public int YearOfEnd { get; set; }//Год окончания
		[DisplayName("Номер телефона")]
		public string Phone { get; set; }//Телефон номер
		[DisplayName("Автобиография")]
		public string Bio { get; set; }//автобиография
		[DisplayName("Фото")]
		public string Image { get; set; }//фото

		[DisplayName("Загрузка фото")]
		public IFormFile ImageFile { get; set; }

		[DisplayName("Должность")]
		public string Position { get; set; }//должность

		//из того файла
		[DisplayName("Пол")]
		public string Gender { get; set; }//пол
		[DisplayName("Дата рождения")]
		public DateTime Birthday { get; set; }//дата рождения
		[DisplayName("ИНН")]
		public string Inn { get; set; }//ИНН
		[DisplayName("Код Специальности")]
		public string SpecialityCode { get; set; }//код специальности
		[DisplayName("Специальност")]
		public string Speciality { get; set; }//ихтитсос
		[DisplayName("Почта")]
		public string Mail { get; set; }//почта для указания самих
		[DisplayName("Мобильный телефон")]
		public string MobilePhone { get; set; }//мобилный телефон
		[DisplayName("Домашный номер")]
		public string HomePhone { get; set; }//домашный телефон
		[DisplayName("Степень обучения")]
		public string LevelOfEducation { get; set; }//зинаи тахсил
		[DisplayName("Форма обучения")]
		public string FormOfEducation { get; set; }//щакли тахсил
		[DisplayName("Квота")]
		public bool Quote { get; set; }//квота
		[DisplayName("Получил диплом?")]
		public bool GetDiplom { get; set; }//Диплом гирифт?
		[DisplayName("Получен ли красный диплом")]
		public bool GetExcelantDiplom { get; set; }//Дипломи аъло гирифт?
		[DisplayName("Отправлен ли на работу")]
		public bool SendToJob { get; set; }//Ба чои кор фиристода шуд?
		[DisplayName("Трудоустроен?")]
		public bool IsEmployed { get; set; }//Бо чои кор таъмин шуд?
		[DisplayName("Пошел ли работать?")]
		public bool ArrivedToJob { get; set; }//Ба чои кор хозир шуд?
		[DisplayName("Регион")]
		public string Region { get; set; }//Ноxия(шаxр)

		//Из второго файла 
		[DisplayName("Место рождения")]
		public string BirthPlace { get; set; }//место рожения
		[DisplayName("Национальност")]
		public string Nationality { get; set; }//миллат
		[DisplayName("Образования")]
		public string Qualification { get; set; }//Таxсилот оли 
		[DisplayName("Ученая степень")]
		public string AcademicDegree { get; set; }//Унвони илмї: 
		[DisplayName("Какие языки знает?")]
		public string Languages { get; set; }//Кадом забонњои хориљиро медонад 
		[DisplayName("Является ли депутатом")]
		public string IsDeptuies { get; set; }//Вакили Маљлиси вакилони халќ њаст ё не 
		[DisplayName("Получал ли государственные награды")]
		public string IsAwarded { get; set; }//Бо мукофотњои давлатї сарфароз гардонида шудааст ё не 
		[DisplayName("Получал ли отраслевые награды")]
		public string IsSectoralAwarded { get; set; }//Бо мукофотњои соњавї сарфароз гардонида шудааст

		[DisplayName("Семейное положение")]
		public string MaritalStatus { get; set; }//Вазъи оилавї  
		[DisplayName("Работа и предыдущий опыт")]
		public string Note { get; set; }//Кор ва фаъолияти собиќа: 



		//Student
		[DisplayName("Основа обучения")]
		public string BasisOfLearning { get; set; }//основа обучения
		[DisplayName("Количество задолженностей")]
		public int CreditQty { get; set; }// кол задолженностей
		[DisplayName("Код группы")]
		public int GroupCode { get; set; }      //код группы

		//Teacher
		[DisplayName("Кафедра")]
		public int DepartmentId { get; set; }

		public virtual RoleView UserRole { get; set; }
	}
}
