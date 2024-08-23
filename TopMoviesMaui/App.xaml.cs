using TopMoviesMaui.Bootstrap;
using TopMoviesMaui.Services.Navigation;
using TopMoviesMaui.Views;

namespace TopMoviesMaui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        InitializeApp();
        InitializeNavigation();
         
	}

    private void InitializeApp()
    {
       // MainPage = new StringView();
        //Akavache.Registrations.Start("TopMovies");//Necessario para que akavache faca seu trabalho
        AppContainer.RegisterDependencies();// Registro VM, Interfaces e Servicos
        SentrySdk.CaptureMessage("Hello Sentry");
    }

    private async Task InitializeNavigation()
    {
        //Resolve : casos em que eh necessario instancia, e nao ha injecao de dependencia no construtor(casos VM)
        var navigationService = AppContainer.Resolve<INavigationService>();
        await navigationService.InitializeAsync();// Inicia a pagina Inicial
    }
}

