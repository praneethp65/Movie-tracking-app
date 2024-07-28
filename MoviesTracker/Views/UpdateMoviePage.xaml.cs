using MoviesTracker.ViewModels;

namespace MoviesTracker.Views
{
    public partial class UpdateMoviePage : ContentPage
    {
        public UpdateMoviePage(UpdateMovieViewModel updateMovieViewModel)
        {
            InitializeComponent();
            BindingContext = updateMovieViewModel;
        }
    }
}
