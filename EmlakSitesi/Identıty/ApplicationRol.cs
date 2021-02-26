using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakSitesi.Identıty
{
    public class ApplicationRol:IdentityRole
    {
        public string Description { get; set; }
        public ApplicationRol()
        {

        }
        public ApplicationRol(string rolname,string description)
        {
            this.Description = description;
        }
    }

}