using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EssentialMAUIUIKit.ViewModel;

namespace EssentialMAUIUIKit
{
    public class MyCardsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CardDetail>? cardDetails;

        public MyCardsViewModel()
        {
            // Seed data is loaded in the constructor from the centralized
            // mock data service so the page itself can stay declarative
            // and consumers do not have to call PopulateData from the
            // code-behind.
            CardDetails = new ObservableCollection<CardDetail>(
                TransactionMockDataService.GetSavedCards());
        }

        public ObservableCollection<CardDetail>? CardDetails
        {
            get => cardDetails;
            set
            {
                cardDetails = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CardDetail
    {
        public string? CardType { get; set; }
        public string? Number { get; set; }
        public string? Name { get; set; }
        public string? Expiry { get; set; }
        public string? CardCvv { get; set; }
        public string? BackgroundGradientStart { get; set; }
        public string? BackgroundGradientEnd { get; set; }
        public string? CardTypeIcon { get; set; }
    }
}
