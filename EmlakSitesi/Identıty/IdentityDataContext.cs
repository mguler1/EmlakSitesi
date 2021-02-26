using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakSitesi.Identıty
{
    public class IdentityDataContext:IdentityDbContext<ApplicationUSer>
    {
        public IdentityDataContext():base("IdentityConnection")
        {

        }
    }
}