using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SaleTrack.State
{
    [JsonObject("AppState")]
    public class AppState
    {
        // 🔐 Authentication
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
        [JsonProperty("lastSignInTime")]
        public DateTime LastSignInTime { get; set; }

        // 👤 User Info
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; } // admin | boss | user

        // 🌐 Network / App Flags
        [JsonProperty("isOnline")]
        public bool IsOnline => Connectivity.Current.NetworkAccess == NetworkAccess.Internet;

        // 📄 Cached URLs
        [JsonProperty("lastGeneratedReportUrl")]
        public string LastGeneratedReportUrl { get; set; }

        // 🧠 App Lifecycle
        [JsonProperty("isInitialized")]
        public bool IsInitialized { get; set; }
    }

}
