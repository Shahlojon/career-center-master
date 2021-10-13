using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CareerCenter.MVC.Models
{
    public class SignUpViewModel
    {
        [Required]
        [Display(Name = "E-Mail ������")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "������ ������ ��������� ����� 100 ��������"), MinLength(6, ErrorMessage = "������ ������ ��������� ����� 6 ��������")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "���")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "������ �� ���������")]
        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }
    }
}
