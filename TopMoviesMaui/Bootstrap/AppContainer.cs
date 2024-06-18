using Autofac;
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
            builder.RegisterType<FlyoutMenuPageViewModel>();
            builder.RegisterType<FlyoutSamplePageViewModel>();
            builder.RegisterType<UpComingViewModel>();
            

            //services - data
            builder.RegisterType<UpComing>().As<IUpComing>();

            //services - general
            //builder.RegisterType<ConnectionService>().As<IConnectionService>();

            //General
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<GenericRepository>().As<IGenericRepository>();
          

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