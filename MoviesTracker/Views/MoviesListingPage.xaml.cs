using MoviesTracker.ViewModels;

namespace MoviesTracker.Views
{
    public partial class MoviesListingPage : ContentPage
    {
        public MoviesListingPage(MoviesListingViewModel moviesListingViewModel)
        {
            InitializeComponent();
            BindingContext = moviesListingViewModel;
        }
    }
}
