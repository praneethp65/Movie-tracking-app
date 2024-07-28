using MoviesTracker.Models;
using MoviesTracker.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MoviesTracker.ViewModels
{
    public partial class AddMovieViewModel : ObservableObject
    {
        private readonly IDataService _dataService;

        [ObservableProperty]
        private string _movieTitle;
        [ObservableProperty]
        private string _movieDirector;
        [ObservableProperty]
        private string _movieImageUrl;
        [ObservableProperty]
        private bool _movieIsFinished;
        [ObservableProperty]
        private DateTime _movieReleaseDate; 
        public AddMovieViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _movieReleaseDate = DateTime.Now; 
        }

        [RelayCommand]
        private async Task AddMovie()
        {
            try
            {
                if (!string.IsNullOrEmpty(MovieTitle))
                {
                    Movie movie = new()
                    {
                        Title = MovieTitle,
                        Director = MovieDirector,
                        ImageUrl = MovieImageUrl,
                        IsFinished = MovieIsFinished,
                        ReleaseDate = MovieReleaseDate 
                    };
                    await _dataService.CreateMovie(movie);

                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "No title!", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
