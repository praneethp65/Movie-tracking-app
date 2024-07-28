using MoviesTracker.Services;
using MoviesTracker.ViewModels;
using MoviesTracker.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MoviesTracker
{
    public partial class App : Application
    {
        public static Supabase.Client SupabaseClient { get; private set; }
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            InitializeComponent();

            SupabaseClient = new Supabase.Client(AppConfig.SUPABASE_URL, AppConfig.SUPABASE_KEY);
            SupabaseClient.InitializeAsync().Wait();

            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();
            var mainPage = ServiceProvider.GetRequiredService<AppShell>();

            MainPage = mainPage;
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<IDataService, DataService>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<SignUpViewModel>();
            services.AddTransient<MoviesListingViewModel>();
            services.AddSingleton<AppShell>();
        }
    }
}
