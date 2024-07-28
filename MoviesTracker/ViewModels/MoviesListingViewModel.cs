using MoviesTracker.Models;
using MoviesTracker.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MoviesTracker.ViewModels
{
    public partial class MoviesListingViewModel : ObservableObject
    {
        private readonly IDataService _dataService;
        private readonly IAuthService _authService;

        public ObservableCollection<Movie> Movies { get; set; } = new();

        public MoviesListingViewModel(IDataService dataService, IAuthService authService)
        {
            _dataService = dataService;
            _authService = authService;
        }

        [RelayCommand]
        public async Task GetMovies()
        {
            Movies.Clear();

            try
            {
                var movies = await _dataService.GetMovies();

                if (movies.Any())
                {
                    foreach (var movie in movies)
                    {
                        Movies.Add(movie);
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        [RelayCommand]
        private async Task AddMovie() => await Shell.Current.GoToAsync("AddMoviePage");

        [RelayCommand]
        private async Task DeleteMovie(Movie movie)
        {
            var result = await Shell.Current.DisplayAlert("Delete", $"Are you sure you want to delete \"{movie.Title}\"?", "Yes", "No");

            if (result)
            {
                try
                {
                    await _dataService.DeleteMovie(movie.Id);
                    await GetMovies();
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }

        [RelayCommand]
        private async Task UpdateMovie(Movie movie) => await Shell.Current.GoToAsync("UpdateMoviePage", new Dictionary<string, object>
        {
            {"MovieObject", movie }
        });

        private async Task OnLogout()
        {
            try
            {
                await _authService.SignOut();
                await Shell.Current.GoToAsync("///LoginPage");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Logout failed: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        private async Task Logout()
        {
            await _authService.SignOut();
            await Shell.Current.GoToAsync("///LoginPage");
        }
    }
}
