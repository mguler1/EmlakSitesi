using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakSitesi.Models
{
    public class Mahalle
    {
        public int MahalleId { get; set; }
        public string MahalleAd { get; set; }
        public int SemtId { get; set; }
        public virtual Semt Semt  { get; set; } //Her bir mahallenin bir tane semti olması için
    }
}