using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakSitesi.Models
{
    public class Durum
    {
        public int DurumID { get; set; }
        public string DurumAd { get; set; }
        public List<Tip> Tips { get; set; }
    }
}