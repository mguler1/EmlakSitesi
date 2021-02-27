using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace EmlakSitesi.Identıty
{
    public class IdentityInitializer:CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if (!context.Roles.Any(i=>i.Name=="admin"))//admin rolü yok ise oluştur
            {
                var store = new RoleStore<ApplicationRol>(context);
                var manager = new RoleManager<ApplicationRol>(store);
                var role = new ApplicationRol() { Name = "admin", Description = "admin rolü" };
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))//admin rolü yok ise oluştur
            {
                var store = new RoleStore<ApplicationRol>(context);
                var manager = new RoleManager<ApplicationRol>(store);
                var role = new ApplicationRol() { Name = "user", Description = "user rolü" };
                manager.Create(role);
            }
            if (!context.Users.Any(i=>i.Name=="güler"))//bu isimde kullanıcı var mı diye kotrol ediyoruz
            {
                var store = new UserStore<ApplicationUSer>(context);
                var manager = new UserManager<ApplicationUSer>(store);
                var user = new ApplicationUSer() { Name = "mehdi", SurName = "güler" ,UserName="deneme",Email="deneme.guler@gmail.com"};
                manager.Create(user,"123456");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }
            if (!context.Users.Any(i => i.Name == "glr"))//bu isimde kullanıcı var mı diye kotrol ediyoruz
            {
                var store = new UserStore<ApplicationUSer>(context);
                var manager = new UserManager<ApplicationUSer>(store);
                var user = new ApplicationUSer() { Name = "mm", SurName = "g", UserName = "deneme2", Email = "mmguler.guler@gmail.com" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "user");
            }
            base.Seed(context);

        }
    }
}
