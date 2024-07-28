using MoviesTracker.Views;

namespace MoviesTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            RegisterForRoute<AddMoviePage>();
            RegisterForRoute<UpdateMoviePage>();
        }

        protected void RegisterForRoute<T>()
        {
            Routing.RegisterRoute(typeof(T).Name, typeof(T));
        }
    }
}
