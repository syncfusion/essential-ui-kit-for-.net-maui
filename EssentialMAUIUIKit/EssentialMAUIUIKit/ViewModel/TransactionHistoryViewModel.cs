using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
			var today = DateTime.Now.Date;

			var list = new List<TransactionDetail>
			{
				new TransactionDetail {
					CustomerName="Alice",
					CustomerImage="ProfileImage15.png",
					AmountValue=70,
					IsCredited=true,
					TransactionDateTime=today.AddHours(12),
					GroupHeader=GetGroupHeader(today.AddHours(12), today)
				},
				new TransactionDetail {
					CustomerName="Shell petrol bunk", 
					AmountValue=180,					
					TransactionDateTime=today.AddHours(10),
					GroupHeader=GetGroupHeader(today.AddHours(10), today)
				},
				new TransactionDetail {
					CustomerName="Lisa",
					CustomerImage="ProfileImage11.png",
					AmountValue=50,
					IsFailed=true,
					TransactionDateTime=today.AddHours(9),
					GroupHeader=GetGroupHeader(today.AddHours(9), today)
				},
				new TransactionDetail {
					CustomerName="Mark",
					CustomerImage="ProfileImage3.png",
					AmountValue=45,
					TransactionDateTime=today.AddHours(8),
					GroupHeader=GetGroupHeader(today.AddHours(8), today)
				},

				// ✅ YESTERDAY
				new TransactionDetail {
					CustomerName="Recharge",
					AmountValue=50,
					TransactionDateTime=today.AddDays(-1).AddHours(13),
					GroupHeader=GetGroupHeader(today.AddDays(-1).AddHours(13), today)
				},
				new TransactionDetail {
					CustomerName="Steve",
					CustomerImage="ProfileImage2.png",
					IsCredited=true,
					AmountValue=80,
					TransactionDateTime=today.AddDays(-1).AddHours(11),
					GroupHeader=GetGroupHeader(today.AddDays(-1).AddHours(11), today)
				},
				new TransactionDetail {
					CustomerName="Rebecca",
					CustomerImage="ProfileImage12.png",
					AmountValue=120,
					IsFailed=true,
					TransactionDateTime=today.AddDays(-1).AddHours(10),
					GroupHeader=GetGroupHeader(today.AddDays(-1).AddHours(10), today)
				}
			};

			var sorted = list.OrderByDescending(x => x.TransactionDateTime).ToList();
			bool yesterdayHeaderShown = false;

			foreach (var item in sorted)
			{
				item.ShowHeader = item.GroupHeader == "Yesterday" && !yesterdayHeaderShown;

				if (item.ShowHeader)
				{
					yesterdayHeaderShown = true;
				}
			}

			TransactionDetails = new ObservableCollection<TransactionDetail>(sorted);
		}

		private static string GetGroupHeader(DateTime transactionDateTime, DateTime referenceDate)
		{
			if (transactionDateTime.Date == referenceDate.Date.AddDays(-1))
			{
				return "Yesterday";
			}

			return string.Empty;
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

		public string GroupHeader { get; set; } = string.Empty;


		public string DisplayDate =>
			TransactionDateTime.ToString("dd MMM yyyy ");

		public string DisplayTime =>
			TransactionDateTime.ToString(" 'at' hh:mm tt");


		public string DisplayAmount =>
			IsCredited ? $"+${AmountValue}" : $"${AmountValue}";

		public bool UseAvatar =>
			CustomerName == "Shell petrol bunk" || CustomerName == "Recharge";

		public bool ShowHeader { get; set; }
	}
}
