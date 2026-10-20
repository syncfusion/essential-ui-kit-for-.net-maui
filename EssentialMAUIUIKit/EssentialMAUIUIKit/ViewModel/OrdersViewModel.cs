using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class OrdersViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Order>? orders;
        private ObservableCollection<Order>? requestedOrders;
        private ObservableCollection<Order>? completedOrders;
        private ObservableCollection<Order>? cancelledOrders;

		private ObservableCollection<Order>? filteredOrders;
		private ObservableCollection<string>? tabs;		

		private string selectedTab = "All Orders";


		public OrdersViewModel()
        {
            PopulateData();

			Tabs = new ObservableCollection<string>
		    {
			    "All Orders",
			    "Ordered",
			    "Cancelled",
			    "Completed"
		    };

            SelectedTab = "All Orders";
			FilteredOrders = Orders;

		}


		public ObservableCollection<string>? Tabs
		{
			get => tabs;
			set
			{
				tabs = value;
				OnPropertyChanged();
			}
		}


		public string SelectedTab
		{
			get => selectedTab;
			set
			{
				selectedTab = value;
				UpdateFilter();
				OnPropertyChanged();
			}
		}


		public ObservableCollection<Order>? Orders
        {
            get => orders;
            set
            {
                orders = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Order>? RequestedOrders
        {
            get => requestedOrders;
            set
            {
                requestedOrders = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Order>? CompletedOrders
        {
            get => completedOrders;
            set
            {
                completedOrders = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Order>? CancelledOrders
        {
            get => cancelledOrders;
            set
            {
                cancelledOrders = value;
                OnPropertyChanged();
            }
        }


		public ObservableCollection<Order>? FilteredOrders
		{
			get => filteredOrders;
			set
			{
				filteredOrders = value;
				OnPropertyChanged();
			}
		}

		// Filtering Logic
		private void UpdateFilter()
		{

        ApplyStatusVisibility(Orders, SelectedTab == "All Orders");
        ApplyStatusVisibility(RequestedOrders, false);
        ApplyStatusVisibility(CancelledOrders, false);
        ApplyStatusVisibility(CompletedOrders, false);

			switch (SelectedTab)
			{

				case "Completed":
					FilteredOrders = CompletedOrders;
					break;

				case "Cancelled":
					FilteredOrders = CancelledOrders;
					break;

				case "Ordered":
					FilteredOrders = RequestedOrders;
					break;

				default:
					FilteredOrders = Orders;
					break;
			}
		}

        private static void ApplyStatusVisibility(ObservableCollection<Order>? source, bool isVisible)
        {
            if (source == null)
            {
                return;
            }

            foreach (var item in source)
            {
                item.ShowStatus = isVisible;
            }
        }


		public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void PopulateData()
        {
            string jsonData = @"
            {
                ""orders"": [
                    {
                        ""orderid"": ""63428737"",
                        ""productimage"": ""Image2.png"",
                        ""name"": ""Peasant Blouse"",
                        ""description"": ""Order was cancelled."",
                        ""status"": ""Cancelled""
                    },
                    {
                        ""orderid"": ""83533963"",
                        ""productimage"": ""Image1.png"",
                        ""name"": ""Full-Length Skirt"",
                        ""description"": ""Delivery expected on 10 Aug 2026."",
                        ""status"": ""Dispatched""
                    },
                    {
                        ""orderid"": ""83658319"",
                        ""productimage"": ""Image3.png"",
                        ""name"": ""Long Skirt with Ethnic Top"",
                        ""description"": ""Delivered on 04 Aug 2026."",
                        ""status"": ""Completed""
                    },
                    {
                        ""orderid"": ""83658319"",
                        ""productimage"": ""Image4.png"",
                        ""name"": ""Winter Casual Outfit"",
                        ""description"": ""Delivery expected on 10 Aug 2026."",
                        ""status"": ""Dispatched""
                    },
                    {
                        ""orderid"": ""83658319"",
                        ""productimage"": ""Image5.png"",
                        ""name"": ""Midi Dress"",
                        ""description"": ""Order was cancelled."",
                        ""status"": ""Cancelled""
                    }
                ]
            }";
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var ordersList = JsonSerializer.Deserialize<OrdersList>(jsonData, options);
            var images = new List<string>() { "Image1.png", "Image2.png", "Image3.png", "Image4.png", "Image5.png" };
            Orders = new ObservableCollection<Order>();
            CancelledOrders = new ObservableCollection<Order>();
            CompletedOrders = new ObservableCollection<Order>();
            RequestedOrders = new ObservableCollection<Order>();
            if (ordersList != null && ordersList.Orders != null)
            {
                for (int i = 0; i < ordersList.Orders.Count && i < images.Count; i++)
                {
                    var sourceOrder = ordersList.Orders[i];
                    var order = new Order
                    {
                        OrderId = sourceOrder.OrderId,
                        ProductImage = images[i],
                        Name = sourceOrder.Name,
                        Description = sourceOrder.Description,
                        Status = sourceOrder.Status
                    };

                    Orders.Add(order);

                    if (order.Status == "Cancelled")
                    {
                        CancelledOrders.Add(new Order
                        {
                            OrderId = order.OrderId,
                            ProductImage = images[i],
                            Name = order.Name,
                            Description = order.Description,
                            Status = order.Status
                        });
                    }

                    if (order.Status == "Dispatched")
                    {
                        RequestedOrders.Add(new Order
                        {
                            OrderId = order.OrderId,
                            ProductImage = images[i],
                            Name = order.Name,
                            Description = order.Description,
                            Status = order.Status
                        });
                    }

                    if (order.Status == "Completed")
                    {
                        CompletedOrders.Add(new Order
                        {
                            OrderId = order.OrderId,
                            ProductImage = images[i],
                            Name = order.Name,
                            Description = order.Description,
                            Status = order.Status
                        });
                    }
                }
            }

            ApplyStatusVisibility(Orders, true);
            ApplyStatusVisibility(RequestedOrders, false);
            ApplyStatusVisibility(CancelledOrders, false);
            ApplyStatusVisibility(CompletedOrders, false);
            FilteredOrders = Orders;
        }
    }

    public class Order : INotifyPropertyChanged
    {
        private string? productImage;
        private bool showStatus;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string? OrderId { get; set; }
        public string ProductImage
        {
            get { return App.ImageServerPath + this.productImage; }
            set { this.productImage = value; }
        }

		public bool ShowStatus
        {
            get => showStatus;
            set
            {
                if (showStatus == value)
                {
                    return;
                }

                showStatus = value;
                OnPropertyChanged();
            }
        }

		public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
    }

    public class OrdersList
    {
        public List<Order>? Orders { get; set; }
    }
}
