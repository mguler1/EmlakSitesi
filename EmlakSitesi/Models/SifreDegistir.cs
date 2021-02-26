using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmlakSitesi.Models
{
    public class SifreDegistir
    {
        [Required]
        [DisplayName("Mevcut Şifreniz")]
        public string Oldpassword { get; set; }
        [Required]
        [DisplayName("Yeni Şifreniz")]
        [StringLength(100,MinimumLength =5,ErrorMessage ="Şifreniz En Az 5 karakter olmalıdır")]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("Yeni Şifreniz Tekrar")]
        [Compare("NewPassword",ErrorMessage ="Şifreler Aynı Değil")]
        public string ConNewPassword { get; set; }

    }
}