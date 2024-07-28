using MoviesTracker.ViewModels;

namespace MoviesTracker.Views
{
    public partial class AddMoviePage : ContentPage
    {
        public AddMoviePage(AddMovieViewModel addMovieViewModel)
        {
            InitializeComponent();
            BindingContext = addMovieViewModel;
        }
    }
}
