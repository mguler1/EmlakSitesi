using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmlakSitesi.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adı")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyadı")]
        public string SurName { get; set; }
        [Required]
        [DisplayName("Mail Adresi")]
        [EmailAddress(ErrorMessage ="Geçersiz E mail Adresi Girdiniz")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="Şifreler Aynı Değil")]
        [DisplayName("Şifre Tekrar")]
        public string RePassword { get; set; }

    }
}