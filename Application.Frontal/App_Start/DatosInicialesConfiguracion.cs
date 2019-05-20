using Application.bbdd;
using Application.bbdd.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Application.Frontal.App_Start
{
    public class DatosInicialesConfiguracion
    {
        public async static void Load()
        {
            using(var ctx = new ApplicationDbContext())
            {

                DbContextTransaction transaction = null;
                transaction = ctx.Database.BeginTransaction();

                if (!ctx.Roles.Any())
                {
                    var roleStore = new RoleStore<ApplicationRole>(ctx);
                    var roleManager = new RoleManager<ApplicationRole>(roleStore);

                    roleManager.Create(new ApplicationRole { Name = "Admin",Active=true });
                    roleManager.Create(new ApplicationRole { Name = "General",Active=true });

                }

                if (!ctx.Users.Any())
                {
                    var userStore = new UserStore<ApplicationUser, ApplicationRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>(ctx);
                    var userManager = new ApplicationUserManager(userStore);

                    var _user = new ApplicationUser
                    {
                        Email = "jimovellan@gmail.com",
                        PhoneNumber = "+20 12 23461340",
         
                        UserName = "Admin"
                    };
                    userManager.Create(_user, "pass@word");
                    userManager.AddToRole(_user.Id, "Admin"); /* IdentityRole error here */

                }

                ctx.SaveChanges();
                transaction.Commit();
                ////create Roles
                //var rolestore = new RoleStore<ApplicationRole>(ctx);
                //var rolemanager = new ApplicationRoleManager(rolestore);
                //var role = new ApplicationRole();

                //if (!await rolemanager.RoleExistsAsync("general"))
                //{
                //    role.Active = true;
                //    role.Name = "general";
                //    var r = await rolemanager.CreateAsync(role);
                //}

                //if (!await rolemanager.RoleExistsAsync("admin"))
                //{
                //    role = new ApplicationRole();
                //    role.Active = true;
                //    role.Name = "Admin";
                //    var r = await rolemanager.CreateAsync(role);
                //}

                //var store = new UserStore<ApplicationUser>(ctx);
                //var manager = new ApplicationUserManager(store);

                //var user = await manager.FindByNameAsync("Administrator");
                //if (user == null || String.IsNullOrEmpty(user.Id))
                //{
                //    user = new ApplicationUser() { UserName = "Administrator", Email = "jimovellan@gmail.com" };
                //    var u = await manager.CreateAsync(user, "P@ssw0rd1234");
                //    if (u.Succeeded)
                //    {
                //        await manager.AddToRoleAsync(user.Id, role.Id);
                //    }
                //}

            }

        }
    }
}