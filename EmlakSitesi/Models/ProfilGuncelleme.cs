using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmlakSitesi.Models
{
    public class ProfilGuncelleme
    {
        
        public string id { get; set; }
       [ Required]
        [DisplayName("Ad")]
        public string name { get; set; }
        [Required]
        [DisplayName("SoyAd")]
        public string surname { get; set; }
        [Required]
        [DisplayName("Mail Adresi")]
        [EmailAddress(ErrorMessage ="Email Adresi Geeçrsiz")]
        public string email { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string username { get; set; }

    }
}