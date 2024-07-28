using System.Threading.Tasks;
using Supabase;
using MoviesTracker.Models;
using Supabase.Gotrue.Exceptions;

namespace MoviesTracker.Services
{
    public class AuthService : IAuthService
    {
        private readonly Supabase.Client _supabase;

        public AuthService()
        {
            _supabase = new Supabase.Client(AppConfig.SUPABASE_URL, AppConfig.SUPABASE_KEY);
            _supabase.InitializeAsync().Wait();
        }

        public async Task<bool> SignIn(string email, string password)
        {
            var response = await _supabase.Auth.SignIn(email, password);
            return response.User != null;
        }

        public async Task<bool> SignUp(string email, string password)
        {
            try
            {
                var response = await _supabase.Auth.SignUp(email, password);
                return response.User != null;
            }
            catch (GotrueException ex) when (ex.Message.Contains("over_email_send_rate_limit"))
            {
                
                throw new Exception("Email rate limit exceeded. Please try again later.");
            }
            catch (Exception ex)
            {
                
                throw new Exception($"Sign up failed: {ex.Message}");
            }
        }
        public async Task SignOut()
        {
            await _supabase.Auth.SignOut();
        }
    }
}

