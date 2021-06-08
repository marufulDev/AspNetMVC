using AspNetMVC.Implementation;
using AspNetMVC.Infrastructure;
using AspNetMVC.Infrastructure.Contract;
using AspNetMVC.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AspNetMVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IPersonService, PersonService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();


            //kernel.Bind(x => x.FromAssemblyContaining<IMasterRankRepository>().SelectAllClasses().BindDefaultInterfaces());






            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}