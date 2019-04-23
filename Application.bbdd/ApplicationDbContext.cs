using Application.bbdd.Configuration;
using Application.bbdd.Entities;
using Application.bbdd.Entities.Maestros;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.bbdd
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string,IdentityUserLogin,IdentityUserRole,IdentityUserClaim>
    {
        #region DbSet's
        public TipoGasto TiposGasto { get; set; }
        #endregion

       
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigurationEntities(modelBuilder);

        }


        protected void ConfigurationEntities(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TipoGastoEntityConfiguration());
        }
    }
}
