using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Windows.Media.Protection.PlayReady;
using SaleTrack.Helpers;
using Supabase;


namespace SaleTrack.Services
{
    

    public class AuthService
    {
        private Client _client;

        public async Task InitializeAsync()
        {

            _client = new Client(
                Constants.SupabaseUrl,
                Constants.SupabaseAnonKey
            );

            await _client.InitializeAsync();
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            return true;
            var res = await _client.Auth.SignIn(email, password);
            return res != null;
        }

        public string? AccessToken => ""; // _client.Auth.CurrentSession?.AccessToken;
        
    }

}
