using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ListaOsobZaginionych.Models
{
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Imię jest obowiązkowe")]
        [DisplayName("Imię")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Nazwisko jest obowiązkowe")]
        [DisplayName("Nazwisko")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Email jest obowiązkowe")]
        [DisplayName("Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Proszę wprowadzić prawidłowy adres Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Login jest obowiązkowe")]
        [DisplayName("Login")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Hasło jest obowiązkowe")]
        [DisplayName("Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Potwiedź hasło")]
        [Compare("Password", ErrorMessage = "Potwierdź hasło")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public bool IsAdmin { get; set; }
        public bool ConfirmRegistration { get; set; }
    }
}