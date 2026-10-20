using System.Collections.Generic;

namespace EssentialMAUIUIKit.ViewModel
{
    /// <summary>
    /// Centralized, static mock data source for the transaction demo pages.
    /// Keeping the seed content in one place allows checkout, delivery,
    /// payment and saved-card view models to share a single source of truth
    /// rather than each view model carrying its own embedded JSON payload.
    /// </summary>
    internal static class TransactionMockDataService
    {
        /// <summary>
        /// Returns the order item rendered in the checkout order summary.
        /// </summary>
        public static List<OrderItem> GetOrderItems() => new()
        {
            new OrderItem
            {
                ProductId = 1,
                ProductName = "Silk Maxi Column Skirt",
                Variant = "Midnight Grey • Size M",
                Image = "silk_shirt.png",
                ExpectedDelivery = "Delivery expected on Mar 23, 2024",
                OrderId = "Order ID: #89027532",
                Quantity = 1,
                UnitPrice = 140.00m
            }
        };

        /// <summary>
        /// Returns the list of available delivery addresses for the checkout flow.
        /// </summary>
        public static List<DeliveryAddress> GetDeliveryAddresses() => new()
        {
            new DeliveryAddress
            {
                CustomerId = 1,
                CustomerName = "Jessica Reed",
                AddressType = "Default",
                Address = "110 Echo Valley Road, Los Altos, California, United States",
                MobileNumber = "+1 (555) 012-3456"
            },
            new DeliveryAddress
            {
                CustomerId = 1,
                CustomerName = "Workspace",
                AddressType = "Office",
                Address = "500 Terry Francois Street, San Francisco, CA 94158, United States",
                MobileNumber = "+1 (555) 018-1010"
            }
        };

        /// <summary>
        /// Returns the saved payment modes rendered in the checkout payment list.
        /// </summary>
        public static List<PaymentMode> GetPaymentModes() => new()
        {
            new PaymentMode
            {
                PaymentModeName = "Visa ending in 4567",
                CardNumber = "48** **** **** 4567",
                CardTypeIcon = "visa.png",
                Expiry = "Expires 12/28",
                CardType = "VISA"
            },
            new PaymentMode
            {
                PaymentModeName = "Mastercard ending in 2345",
                CardNumber = "52** **** **** 2345",
                CardTypeIcon = "mastercardlogo.png",
                Expiry = "Expires 09/27",
                CardType = "MC"
            }
        };

        /// <summary>
        /// Returns the alternative payment methods shown as quick action tiles.
        /// </summary>
        public static List<QuickPaymentMethod> GetQuickPaymentMethods() => new()
        {
            new QuickPaymentMethod { Name = "Net Banking", IconGlyph = "\ue726" },
            new QuickPaymentMethod { Name = "UPI Pay", IconGlyph = "\ue712" },
            new QuickPaymentMethod { Name = "Cash on Delivery", IconGlyph = "\ue720" }
        };

        /// <summary>
        /// Returns the saved cards rendered on the My Cards page.
        /// </summary>
        public static List<CardDetail> GetSavedCards() => new()
        {
            new CardDetail
            {
                CardType = "CREDIT CARD",
                Number = "XXXX  XXXX  XXXX  5838",
                Name = "Peter Wilson",
                Expiry = "08/20",
                CardCvv = "846",
                BackgroundGradientStart = "#9F60FD",
                BackgroundGradientEnd = "#D957BC",
                CardTypeIcon = "Card.png"
            },
            new CardDetail
            {
                CardType = "DEBIT CARD",
                Number = "XXXX  XXXX  XXXX  0743",
                Name = "Peter Wilson",
                Expiry = "03/21",
                CardCvv = "543",
                BackgroundGradientStart = "#6DB0FF",
                BackgroundGradientEnd = "#6957D9",
                CardTypeIcon = "Visa.png"
            }
        };

        /// <summary>
        /// Returns the price detail line items rendered in the price summary.
        /// </summary>
        public static List<PriceLine> GetPriceLines() => new()
        {
            new PriceLine { Label = "Price (1 Item)", Value = "$450.00" },
            new PriceLine { Label = "Discount", Value = "-$43.00", IsHighlighted = true },
            new PriceLine { Label = "Delivery Charges", Value = "Free", StrikeThroughValue = "$4.00", IsHighlighted = true },
            new PriceLine { Label = "Coupon Applied", Value = "BOUTIQUE20", IsHighlighted = true }
        };
    }

    /// <summary>
    /// Represents a single line item in the checkout order summary.
    /// </summary>
    public class OrderItem
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Variant { get; set; }
        public string? Image { get; set; }
        public string? ExpectedDelivery { get; set; }
        public string? OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    /// <summary>
    /// Represents a quick action payment tile (e.g. Net Banking, UPI, COD).
    /// </summary>
    public class QuickPaymentMethod
    {
        public string? Name { get; set; }
        public string? IconGlyph { get; set; }
    }

    /// <summary>
    /// Represents a single row in the price summary.
    /// </summary>
    public class PriceLine
    {
        public string? Label { get; set; }
        public string? Value { get; set; }
        public string? StrikeThroughValue { get; set; }
        public bool IsHighlighted { get; set; }
    }
}
