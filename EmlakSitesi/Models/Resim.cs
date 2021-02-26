﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakSitesi.Models
{
    public class Resim
    {
        public int ResimId { get; set; }
        public string ResimAd { get; set; }
        public int IlanId { get; set; }
        public virtual Ilan Ilan { get; set; }//ilanın birden fazla resmi var
    }
}