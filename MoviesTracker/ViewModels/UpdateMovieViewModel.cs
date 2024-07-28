using MoviesTracker.Models;
using MoviesTracker.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace MoviesTracker.ViewModels
{
    [QueryProperty(nameof(Movie), "MovieObject")]
    public partial class UpdateMovieViewModel : ObservableObject
    {
        private readonly IDataService _dataService;

        [ObservableProperty]
        private Movie _movie;

        public UpdateMovieViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        [RelayCommand]
        private async Task UpdateMovie()
        {
            if (!string.IsNullOrEmpty(Movie.Title))
            {
                try
                {
                    await _dataService.UpdateMovie(Movie);
                    await Shell.Current.GoToAsync("..");
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "No title!", "OK");
            }
        }
    }
}
