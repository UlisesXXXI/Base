using Application.bbdd;
using Application.bbdd.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
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
                //create Roles
                var rolestore = new RoleStore<ApplicationRole>(ctx);
                var rolemanager = new ApplicationRoleManager(rolestore);
                var role = new ApplicationRole();

                if (!await rolemanager.RoleExistsAsync("general"))
                {
                    role.Active = true;
                    role.Name = "general";
                    var r = await rolemanager.CreateAsync(role);
                }

                if (!await rolemanager.RoleExistsAsync("admin"))
                {
                    role = new ApplicationRole();
                    role.Active = true;
                    role.Name = "Admin";
                    var r = await rolemanager.CreateAsync(role);
                }

                var store = new UserStore<ApplicationUser>(ctx);
                var manager = new ApplicationUserManager(store);
                var user = await manager.FindByNameAsync("Administrator");
                if (user == null || String.IsNullOrEmpty(user.Id))
                {
                    user = new ApplicationUser() { UserName = "Administrator", Email = "jimovellan@gmail.com" };
                    var u = await manager.CreateAsync(user, "P@ssw0rd1234");
                    if (u.Succeeded)
                    {
                        await manager.AddToRoleAsync(user.Id, role.Id);
                    }
                }

            }

        }
    }
}