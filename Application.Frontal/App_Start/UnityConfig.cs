using System.Reflection;
using System.Web.Mvc;
using Unity;
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

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}