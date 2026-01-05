using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SaleTrack.Models
{
    [JsonObject("Report")]
    public class Report
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }
        
        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }

        [JsonProperty("sendEmail")]
        public string SendEmail { get; set; }

        [JsonProperty("pdfUrl")]
        public string PdfUrl { get; set; }

        [JsonIgnore]
        public string DateRange => $"{StartDate} → {EndDate}";
    }

}
