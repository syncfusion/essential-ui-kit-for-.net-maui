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

        public OrdersViewModel()
        {
            PopulateData();
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
                        ""orderid"": ""83533963"",
                        ""productimage"": ""Image1.png"",
                        ""name"": ""Full-Length Skirt"",
                        ""description"": ""Delivery expected on 10 Aug 2019."",
                        ""status"": ""Dispatched""
                    },
                    {
                        ""orderid"": ""63428737"",
                        ""productimage"": ""Image2.png"",
                        ""name"": ""Peasant Blouse"",
                        ""description"": ""Order was cancelled."",
                        ""status"": ""Cancelled""
                    },
                    {
                        ""orderid"": ""83658319"",
                        ""productimage"": ""Image3.png"",
                        ""name"": ""High-Waisted Skirt"",
                        ""description"": ""Delivered on 04 Aug 2019."",
                        ""status"": ""Completed""
                    }
                ]
            }";
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var ordersList = JsonSerializer.Deserialize<OrdersList>(jsonData, options);
            var images = new List<string>() { "Image1.png", "Image2.png", "Image3.png" };
            Orders = new ObservableCollection<Order>();
            CancelledOrders = new ObservableCollection<Order>();
            CompletedOrders = new ObservableCollection<Order>();
            RequestedOrders = new ObservableCollection<Order>();
            if (ordersList != null && ordersList.Orders != null)
            {
                for (int i = 0; i < ordersList.Orders.Count; i++)
                {
                    ordersList.Orders[i].ProductImage = images[i];
                    Orders.Add(ordersList.Orders[i]);

                    if (ordersList.Orders[i].Status == "Cancelled")
                    {
                        CancelledOrders.Add(ordersList.Orders[i]);
                    }

                    if (ordersList.Orders[i].Status == "Dispatched")
                    {
                        RequestedOrders.Add(ordersList.Orders[i]);
                    }

                    if (ordersList.Orders[i].Status == "Completed")
                    {
                        CompletedOrders.Add(ordersList.Orders[i]);
                    }
                }
            }
        }
    }

    public class Order
    {
        private string? productImage;
        public string? OrderId { get; set; }
        public string ProductImage
        {
            get { return App.ImageServerPath + this.productImage; }
            set { this.productImage = value; }
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
