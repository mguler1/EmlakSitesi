using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakSitesi.Models
{
    public class Tip
    {
        public int TipId { get; set; }
        public string TipAd { get; set; }
        public int DurumID { get; set; }
        public virtual Durum Durum { get; set; }
    }
}