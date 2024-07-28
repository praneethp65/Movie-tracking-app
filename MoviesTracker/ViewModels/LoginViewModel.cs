using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MoviesTracker.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MoviesTracker.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        private string _email;
        private string _password;
        private string _errorMessage;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public ICommand LoginCommand { get; }
        public ICommand NavigateToSignUpCommand { get; }

        public LoginViewModel() : this(App.ServiceProvider.GetService<IAuthService>()) { }

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
            LoginCommand = new AsyncRelayCommand(OnLogin);
            NavigateToSignUpCommand = new AsyncRelayCommand(OnNavigateToSignUp);
        }

        private async Task OnLogin()
        {
            if (_authService == null)
            {
                ErrorMessage = "Authentication service is not available.";
                return;
            }

            var success = await _authService.SignIn(Email, Password);
            if (success)
            {
                try
                {
                    await Shell.Current.GoToAsync("//MoviesListingPage");
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
                }
            }
            else
            {
                ErrorMessage = "Login failed. Please try again.";
            }
        }

        private async Task OnNavigateToSignUp()
        {
            try
            {
                await Shell.Current.GoToAsync("///SignUpPage");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
