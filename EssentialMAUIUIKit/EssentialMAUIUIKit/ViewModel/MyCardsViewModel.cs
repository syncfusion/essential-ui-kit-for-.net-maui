using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class MyCardsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CardDetail>? cardDetails;

        public ObservableCollection<CardDetail>? CardDetails
        {
            get => cardDetails;
            set
            {
                cardDetails = value;
                OnPropertyChanged();
            }
        }

        public void PopulateData(string jsonData)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var cardData = JsonSerializer.Deserialize<CardData>(jsonData, options);
                if (cardData?.CardDetails != null)
                {
                    CardDetails = new ObservableCollection<CardDetail>(cardData.CardDetails);
                }
            }
            catch (Exception ex)
            {
                // Handle JSON parsing exceptions
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class CardData
        {
            public List<CardDetail>? CardDetails { get; set; }
        }
    }

    public class CardDetail
    {
        public string? CardType { get; set; }
        public string? Number { get; set; }
        public string? Name { get; set; }
        public string? Expiry { get; set; }
        public int CardCvv { get; set; }
        public string? BackgroundGradientStart { get; set; }
        public string? BackgroundGradientEnd { get; set; }
        public string? CardTypeIcon { get; set; }
    }

}
