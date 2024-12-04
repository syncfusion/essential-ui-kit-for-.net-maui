namespace EssentialMAUIUIKit.Views.Transaction
{
    public partial class MyCardsPage : ContentView
    {
        public MyCardsPage()
        {
            InitializeComponent();
            string jsonData = @"
        {
            ""cardDetails"": [
                {
                    ""cardType"": ""CREDIT CARD"",
                    ""number"": ""XXXX  XXXX  XXXX  5838"",
                    ""name"": ""Peter Wilson"",
                    ""expiry"": ""08/20"",
                    ""cardCvv"": 846,
                    ""backgroundGradientStart"": ""#9F60FD"",
                    ""backgroundGradientEnd"": ""#D957BC"",
                    ""cardTypeIcon"": ""Card.png""
                },
                {
                    ""cardType"": ""DEBIT CARD"",
                    ""number"": ""XXXX  XXXX  XXXX  0743"",
                    ""name"": ""Peter Wilson"",
                    ""expiry"": ""03/21"",
                    ""cardCvv"": 543,
                    ""backgroundGradientStart"": ""#6DB0FF"",
                    ""backgroundGradientEnd"": ""#6957D9"",
                    ""cardTypeIcon"": ""Visa.png""
                },
                {
                    ""cardType"": ""CREDIT CARD"",
                    ""number"": ""XXXX  XXXX  XXXX  0629"",
                    ""name"": ""Peter Wilson"",
                    ""expiry"": ""18/22"",
                    ""cardCvv"": 346,
                    ""backgroundGradientStart"": ""#6DB0FF"",
                    ""backgroundGradientEnd"": ""#6957D9"",
                    ""cardTypeIcon"": ""Card.png""
                }
            ]
        }";

            this.viewModel.PopulateData(jsonData);
        }
    }
}