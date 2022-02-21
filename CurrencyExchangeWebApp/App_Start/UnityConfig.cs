using CurrencyExchangeWebApp.Manager;
using CurrencyExchangeWebApp.Repository;
using CurrencyExchangeWebApp.SortingAlgorithm;
using ServiceCall;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace CurrencyExchangeWebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IService, Service>();
            container.RegisterType<ICurrencyExchangeRatesRepository, CurrencyExchangeRatesRepository>();
            container.RegisterType<ICurrencyExchangeManager, CurrencyExchangeManager>();
            container.RegisterType<IBubbleSort, BubbleSort>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}