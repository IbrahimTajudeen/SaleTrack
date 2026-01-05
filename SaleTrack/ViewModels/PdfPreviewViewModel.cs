using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleTrack.ViewModels
{
    public class PdfPreviewViewModel : BaseViewModel
    {
        public string PdfUrl { get; }

        public PdfPreviewViewModel(string pdfUrl)
        {
            PdfUrl = pdfUrl;
        }
    }

}
