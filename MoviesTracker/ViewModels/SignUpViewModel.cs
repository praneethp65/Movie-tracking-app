using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MoviesTracker.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MoviesTracker.ViewModels
{
    public class SignUpViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        private string _email;
        private string _password;
        private string _confirmPassword;
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

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public ICommand SignUpCommand { get; }
        public ICommand NavigateToLoginCommand { get; }

        public SignUpViewModel() : this(App.ServiceProvider.GetService<IAuthService>()) { }

        public SignUpViewModel(IAuthService authService)
        {
            _authService = authService;
            SignUpCommand = new AsyncRelayCommand(OnSignUp);
            NavigateToLoginCommand = new AsyncRelayCommand(OnNavigateToLogin);
        }

        private async Task OnSignUp()
        {
            ErrorMessage = string.Empty;

            if (_authService == null)
            {
                ErrorMessage = "Authentication service is not available.";
                return;
            }

            if (Password != ConfirmPassword)
            {
                ErrorMessage = "Passwords do not match.";
                return;
            }

            try
            {
                var success = await _authService.SignUp(Email, Password);
                if (success)
                {
                    try
                    {
                        await Shell.Current.GoToAsync("///LoginPage");
                    }
                    catch (Exception ex)
                    {
                        await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
                    }
                }
                else
                {
                    ErrorMessage = "Sign up failed. Please try again.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }

        private async Task OnNavigateToLogin()
        {
            try
            {
                await Shell.Current.GoToAsync("///LoginPage");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
