using EvolentContact.Repo;
using EvolentContact.Services;

using System.Web.Mvc;

using Unity;
using Unity.Mvc5;

namespace EvolentContact
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IContactRepo, ContactRepo>();
            container.RegisterType<IContactService, ContactService>();
        }
    }
}