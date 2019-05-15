using Application.bbdd.Configuration;
using Application.bbdd.Entities;
using Application.bbdd.Entities.Maestros;
using Application.bbdd.Filters;
using EntityFramework.DynamicFilters;
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
        public DbSet<TipoGasto> TiposGasto { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        #endregion

       
        public ApplicationDbContext()
            : base("DefaultConnexion")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            
           
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
            modelBuilder.Configurations.Add(new GastoEntityConfiguration());
        }

        private void Filters(ref DbModelBuilder modelBuilder)
        {
            SoftDeleleteFilter.AddFilter(ref modelBuilder);
        }
    }
}
