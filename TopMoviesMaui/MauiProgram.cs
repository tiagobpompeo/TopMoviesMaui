﻿using Microsoft.Extensions.Logging;
using TopMovies.Business;
using Plugin.Maui.DebugRainbows;
using Firebase.Database;
using TopMoviesMaui.Models;
using Firebase.Database.Query;

namespace TopMoviesMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            //.UseDebugRainbows(new DebugRainbowsOptions
            //{
            //    ShowGrid = true,
            //    ShowRainbows = false,
            //    GridOrigin = DebugGridOrigin.Center
                
            //})
            .UseSentry(options => {
                // The DSN is the only required setting.
                options.Dsn = "https://14bc3a5500ce1e96b9d679db9fa77671@o1326831.ingest.us.sentry.io/4507548914548736";

                // Use debug mode if you want to see what the SDK is doing.
                // Debug messages are written to stdout with Console.Writeline,
                // and are viewable in your IDE's debug console or with 'adb logcat', etc.
                // This option is not recommended when deploying your application.
                options.Debug = true;

                // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
                // We recommend adjusting this value in production.
                options.TracesSampleRate = 1.0;

                // Sample rate for profiling, applied on top of othe TracesSampleRate,
                // e.g. 0.2 means we want to profile 20 % of the captured transactions.
                // We recommend adjusting this value in production.
                options.ProfilesSampleRate = 1.0;

                // Requires NuGet package: Sentry.Profiling
                // Note: By default, the profiler is initialized asynchronously. This can
                // be tuned by passing a desired initialization timeout to the constructor.
                //options.AddIntegration(new ProfilingIntegration(
                //    // During startup, wait up to 500ms to profile the app startup code.
                //    // This could make launching the app a bit slower so comment it out if you
                //    // prefer profiling to start asynchronously
                //    TimeSpan.FromMilliseconds(500)
                //));

                // Other Sentry options can be set here.
            })

          

            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


        //View Model 
        builder.Services.AddTransient<StringViewModel>();
#if DEBUG
        builder.Logging.AddDebug();
#endif
      

        return builder.Build();
	}    

}

