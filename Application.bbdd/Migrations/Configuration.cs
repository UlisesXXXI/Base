namespace Application.bbdd.Migrations
{
    using Application.bbdd.Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Application.bbdd.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Application.bbdd.ApplicationDbContext context)
        {
            if(!context.Roles.Any(r=>r.Name =="Admin"))
            {
              //  var store = new RoleStore<ApplicationRole>(context);
            }
        }
    }
}
