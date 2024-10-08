﻿using Autofac;
using TopMovies.Business;
using TopMoviesMaui.Repository;
using TopMoviesMaui.Services;
using TopMoviesMaui.Services.Navigation;
using TopMoviesMaui.ViewModels;

namespace TopMoviesMaui.Bootstrap
{
    public static class AppContainer
    {
        private static Autofac.IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<FlyoutSamplePageViewModel>();
            builder.RegisterType<FlyoutMenuPageViewModel>();
            builder.RegisterType<UpComingViewModel>();
            builder.RegisterType<UpComingDetailViewModel>();
            builder.RegisterType<TabbedMoviesViewModel>();
            //builder.RegisterType<StringViewModel>();
            

            //services - data
            builder.RegisterType<UpComing>().As<IUpComing>();

            //services - general
            //builder.RegisterType<ConnectionService>().As<IConnectionService>();

            //General
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<GenericRepository>().As<IGenericRepository>();
            builder.RegisterType<GenericRepository>().As<IGenericRepository>();
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