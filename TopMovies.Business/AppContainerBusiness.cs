using System;
using Autofac;

namespace TopMovies.Business
{
    public static class AppContainerBusiness
    {
        private static Autofac.IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<StringViewModel>();
            //services - data           

            //services - general
            //builder.RegisterType<ConnectionService>().As<IConnectionService>();

            //General
            builder.RegisterType<GenericRepositoryBusiness>().As<IGenericRepositoryBusiness>();
            //builder.RegisterType<GenericRepositoryBusiness>().As<IGenericRepositoryBusiness>();

            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        //Resolve : casos em que eh necessario instancia, e nao ha injecao de dependencia no construtor(casos VM)
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}