using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class TransactionHistoryViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TransactionDetail>? transactionDetails;

        public TransactionHistoryViewModel()
        {
            PopulateData();
        }

        public ObservableCollection<TransactionDetail>? TransactionDetails
        {
            get => transactionDetails;
            set
            {
                transactionDetails = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void PopulateData()
        {
            // JSON data string
            string jsonData = @"
            {
             ""transactionDetails"": [
    {
      ""customerName"": ""Alice"",
      ""transactionDescription"": ""Cashback"",
      ""customerImage"": ""ProfileImage15.png"",
      ""transactionAmount"": ""+ $70"",
      ""isCredited"": true,
      ""transactionDate"": ""12 Jan 2024""
    },
    {
      ""customerName"": ""Jessica Park"",
      ""transactionDescription"": ""XXXXXXX6585"",
      ""customerImage"": ""ProfileImage10.png"",
      ""transactionAmount"": ""+ $80"",
      ""isCredited"": true,
      ""transactionDate"": ""18 Jan 2024""
    },
    {
      ""customerName"": ""Lisa"",
      ""transactionDescription"": ""Recharge"",
      ""customerImage"": ""ProfileImage11.png"",
      ""transactionAmount"": ""- $50"",
      ""isCredited"": false,
      ""transactionDate"": ""10 Mar 2024""
    },
    {
      ""customerName"": ""Rebecca"",
      ""transactionDescription"": ""Credit Card Bill"",
      ""customerImage"": ""ProfileImage12.png"",
      ""transactionAmount"": ""- $180"",
      ""isCredited"": false,
      ""transactionDate"": ""12 Mar 2024""
    },
{
      ""customerName"": ""John Chris"",
      ""transactionDescription"": ""Cashback"",
      ""customerImage"": ""ProfileImage1.png"",
      ""transactionAmount"": ""+ $50"",
      ""isCredited"": true,
      ""transactionDate"": ""10 Mar 2024""
    },
    {
      ""customerName"": ""Steve"",
      ""transactionDescription"": ""Household expense"",
      ""customerImage"": ""ProfileImage2.png"",
      ""transactionAmount"": ""- $180"",
      ""isCredited"": false,
      ""transactionDate"": ""12 Mar 2024""
    }
  ]
            }";
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var transactionInfo = JsonSerializer.Deserialize<TransactionInfo>(jsonData, options);
            if (transactionInfo?.TransactionDetails != null)
            {
                TransactionDetails = new ObservableCollection<TransactionDetail>(transactionInfo.TransactionDetails);
            }
        }
    }

    public class TransactionDetail
    {
        private string? customerImage;
        public string? CustomerName { get; set; }
        public string? TransactionDescription { get; set; }
        public string CustomerImage
        {
            get { return App.ImageServerPath + this.customerImage; }
            set { customerImage = value; }
        }

        public string? TransactionAmount { get; set; }
        public string? TransactionDate { get; set; }
        public bool IsCredited { get; set; }
    }

    public class TransactionInfo
    {
        public ObservableCollection<TransactionDetail>? TransactionDetails { get; set; }
    }
}
