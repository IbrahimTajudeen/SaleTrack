using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace SaleTrack.Models
{
    [JsonObject("Sale")]
    public class NewSale : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private DateTime _saleDate = DateTime.Today;
        [JsonProperty("saleDate")]
        public DateTime SaleDate
        {
            get => _saleDate;
            set
            {
                if (_saleDate == value) return;
                _saleDate = value;
                OnPropertyChanged();
            }
        }

        private string _itemName;
        [JsonProperty("itemName")]
        public string ItemName
        {
            get => _itemName;
            set
            {
                if (_itemName == value) return;
                _itemName = value;
                OnPropertyChanged();
            }
        }

        private decimal _pricePerItem;
        [JsonProperty("pricePerItem")]
        public decimal PricePerItem
        {
            get => _pricePerItem;
            set
            {
                if (_pricePerItem == value) return;
                _pricePerItem = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalAmount));
            }
        }

        private int _quantity;
        [JsonProperty("quantity")]
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity == value) return;
                _quantity = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalAmount));
            }
        }

        [JsonIgnore]
        public decimal TotalAmount => PricePerItem * Quantity;

        private string _notes;
        [JsonProperty("notes")]
        public string Notes
        {
            get => _notes;
            set
            {
                if (_notes == value) return;
                _notes = value;
                OnPropertyChanged();
            }
        }
    }

    public class Sale
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("saleDate")]
        public DateTime SaleDate { get; set; } = DateTime.Today;

        [JsonProperty("itemName")]
        public string ItemName { get; set; }

        [JsonProperty("pricePerItem")]
        public decimal PricePerItem { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("totalAmount")]
        public decimal TotalAmount { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }
    }
}
