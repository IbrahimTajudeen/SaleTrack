using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SaleTrack.Models
{
    [JsonObject("ApiResponse")]
    public class ApiResponse<T>
    {
        public ApiResponse() { }
        [JsonProperty("success")]
        public bool Success { get; set; } = false;
        
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    [JsonObject("ApiMessage")]
    public class ApiMessage
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
        
        [JsonProperty("statusCode")]
        public int statusCode { get; set; }
    }

    [JsonObject("ApiError")]
    public class ApiError
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("statusCode")]
        public int statusCode { get; set; }

        [JsonProperty("message")]
        public ApiMessage Message { get; set; }
    }
}
