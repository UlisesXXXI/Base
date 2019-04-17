using Application.bbdd;
using Application.bbdd.Entities.Maestros;
using Application.Dal.Implementacion;
using Application.Dal.Interface;
using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;
using Unity.RegistrationByConvention;

namespace Application.Frontal
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

                container.RegisterTypes(
                AllClasses.FromAssemblies(new[]
                {
                    Assembly.Load("Application.bbdd"),
                    Assembly.Load("Application.Bll"),
                    Assembly.Load("Application.Dal")
                }),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            //mantiene la instancia por hilo
            container.RegisterType<DbContext, ApplicationDbContext>(new PerThreadLifetimeManager());

            container.RegisterType(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}