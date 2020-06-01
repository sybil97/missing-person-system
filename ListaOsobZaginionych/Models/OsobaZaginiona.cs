using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ListaOsobZaginionych.Models
{
    public class OsobaZaginiona
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Imię jest obowiązkowe")]
        [DisplayName("Imię")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Nazwisko jest obowiązkowe")]
        [DisplayName("Nazwisko")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Płeć jest obowiązkowa")]
        [DisplayName("Płeć")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Wiek jest obowiązkowy")]
        [DisplayName("Wiek")]
        public string Age { get; set; }
        [Required(ErrorMessage = "Lokalizacja jest obowiązkowe")]
        [DisplayName("Lokalizacja")]
        public string Lokalizacja { get; set; }
        [Required(ErrorMessage = "Wzrost jest obowiązkowy")]
        [DisplayName("Wzrost")]
        public string Width { get; set; }
        [Required(ErrorMessage = "Kolor oczu jest obowiązkowy")]
        [DisplayName("Kolor oczu")]
        public string Eyecolor { get; set; }
        [Required(ErrorMessage = "Kolor włosów jest obowiązkowy")]
        [DisplayName("Kolor włosów")]
        public string Haircolor { get; set; }
    }
}