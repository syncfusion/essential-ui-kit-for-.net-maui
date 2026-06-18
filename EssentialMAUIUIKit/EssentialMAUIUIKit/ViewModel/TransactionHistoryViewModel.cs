using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class TransactionHistoryViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TransactionDetail>? transactionDetails;

		public ObservableCollection<TransactionHistoryGroup> GroupedTransactions { get; set; }

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
			var today = DateTime.Now.Date;

			var list = new List<TransactionDetail>
			{
				new TransactionDetail {
					CustomerName="Alice",
					CustomerImage="ProfileImage15.png",
					AmountValue=70,
					IsCredited=true,
					TransactionDateTime=today.AddHours(12)
				},
				new TransactionDetail {
					CustomerName="Shell petrol bunk", 
					AmountValue=180,					
					TransactionDateTime=today.AddHours(10)
				},
				new TransactionDetail {
					CustomerName="Lisa",
					CustomerImage="ProfileImage11.png",
					AmountValue=50,
					IsFailed=true,
					TransactionDateTime=today.AddHours(9)
				},

				// ✅ YESTERDAY
				new TransactionDetail {
					CustomerName="Recharge",
					AmountValue=50,
					TransactionDateTime=today.AddDays(-1).AddHours(13)
				},
				new TransactionDetail {
					CustomerName="Steve",
					CustomerImage="ProfileImage2.png",
					IsCredited=true,
					AmountValue=180,
					TransactionDateTime=today.AddDays(-1).AddHours(11)
				},
				new TransactionDetail {
					CustomerName="Rebecca",
					CustomerImage="ProfileImage12.png",
					AmountValue=120,
					IsFailed=true,
					TransactionDateTime=today.AddDays(-1).AddHours(10)
				}
			};

			bool headerShown = false;

			foreach (var item in list.OrderByDescending(x => x.TransactionDateTime))
			{
				if (item.GroupHeader == "Yesterday" && !headerShown)
				{
					item.ShowHeader = true;
					headerShown = true;
				}
			}

			TransactionDetails =
				new ObservableCollection<TransactionDetail>(
					list.OrderByDescending(x => x.TransactionDateTime));
		}


	}



	public class TransactionDetail
	{
		private string? customerImage;

		public string? CustomerName { get; set; }

		public string CustomerImage
		{
			get => App.ImageServerPath + this.customerImage;
			set => customerImage = value;
		}

		public bool IsCredited { get; set; }

		public bool IsFailed { get; set; }

		public double AmountValue { get; set; }

		public DateTime TransactionDateTime { get; set; }

		public string DisplayDateTime =>
			TransactionDateTime.ToString("dd MMM yyyy 'at' hh:mm tt");

		public string DisplayAmount =>
			IsCredited ? $"+${AmountValue}" : $"${AmountValue}";

		public bool UseAvatar =>
			CustomerName == "Shell petrol bunk" || CustomerName == "Recharge";

		public string GroupHeader =>
			TransactionDateTime.Date == DateTime.Now.Date.AddDays(-1)
				? "Yesterday"
				: "";

		public bool ShowHeader { get; set; }
	}



	public class TransactionHistoryGroup : ObservableCollection<TransactionDetail>
	{
		public string? Title { get; set; }

		public TransactionHistoryGroup(string? title, IEnumerable<TransactionDetail> items)
			: base(items)
		{
			Title = title;
		}
	}


	public class TransactionInfo
    {
        public ObservableCollection<TransactionDetail>? TransactionDetails { get; set; } = new ObservableCollection<TransactionDetail>();
    }
}
