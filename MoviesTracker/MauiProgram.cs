using MoviesTracker.Models;
using MoviesTracker.Services;
using MoviesTracker.ViewModels;
using MoviesTracker.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Supabase;

namespace MoviesTracker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Configure Supabase
            var url = AppConfig.SUPABASE_URL;
            var key = AppConfig.SUPABASE_KEY;
            builder.Services.AddSingleton(provider => new Supabase.Client(url, key));

            // Add ViewModels
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<SignUpViewModel>();
            builder.Services.AddSingleton<MoviesListingViewModel>();
            builder.Services.AddTransient<AddMovieViewModel>();
            builder.Services.AddTransient<UpdateMovieViewModel>();

            // Add Views
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<SignUpPage>();
            builder.Services.AddSingleton<MoviesListingPage>();
            builder.Services.AddTransient<AddMoviePage>();
            builder.Services.AddTransient<UpdateMoviePage>();

            // Add Data Service
            builder.Services.AddSingleton<IAuthService, AuthService>();
            builder.Services.AddSingleton<IDataService, DataService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
