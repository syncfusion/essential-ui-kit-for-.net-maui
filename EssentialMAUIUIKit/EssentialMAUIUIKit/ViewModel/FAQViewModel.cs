using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class FAQViewModel
    {
        public ObservableCollection<QuestionItem> QuestionsList { get; set; }

        public FAQViewModel()
        {
            QuestionsList = new ObservableCollection<QuestionItem>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""questions"": [
                {
                    ""question"": ""How do I return or exchange an item?"",
                    ""answer"": [
                        ""To return or exchange your order, follow these simple steps :"",
                        ""1. Go to My Orders."",
                        ""2. Choose the item you wish to return."",
                        ""3. Fill in the details."",
                        ""4. Tap Request Return.""
                    ]
                },
                {
                    ""question"": ""What is the replacement process for orders?"",
                    ""answer"": [
                        ""1. Upon clicking Request Return, a replacement item will be shipped to you automatically, free of charge."",
                        ""2. If the damaged item is not received by our warehouse within 15 days, you will be charged for the replacement item.""
                    ]
                },
                {
                    ""question"": ""Why haven't I received my refund in my bank account yet?"",
                    ""answer"": [
                        ""Refunds can take up to 10 business days to process after our warehouse receives the returned item. If you have not received your refund after 10 days plus shipping time, please contact returns@coolxxstuff.com.""
                    ]
                },
                {
                    ""question"": ""When are refunds given?"",
                    ""answer"": [
                        ""If a refund is requested within 30 days of receiving the product, refunds will be processed within 10 days of the returned product delivery to our warehouse. Please allow for shipping time.""
                    ]
                },
                {
                    ""question"": ""Why are faster delivery options not available at my location?"",
                    ""answer"": [
                        ""We use FedEx to deliver our products. All estimates for shipping times and all available shipping options come from calculations on their website.""
                    ]
                },
                {
                    ""question"": ""I have requested a return for my item. When will it happen?"",
                    ""answer"": [
                        ""If you have requested a return within 30 days of receiving your item, approval will be automatic and a shipping label will be printable from your device. Your refund will be processed within 10 days of your items delivery to our warehouse.""
                    ]
                },
                {
                    ""question"": ""How do I get an invoice for my order?"",
                    ""answer"": [
                        ""Invoices are automatically sent to the email you provided during the purchasing process. If you did not receive an invoice, please contact xxxx@coolxxstuff.com""
                    ]
                },
                {
                    ""question"": ""How do I deactivate my account?"",
                    ""answer"": [
                        ""To deactivate your account:"", 
                        ""1. Go to My Account."",
                        ""2. Click Manage My Account."",
                        ""3. Near the bottom of the screen is a Deactivate option. Click it."",
                        ""4. Confirm that you want to deactivate your account."",
                        ""An email will be sent to you confirming your accounts deactivation.""
                    ]
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<QuestionsData>(jsonData, options);

            if (data?.Questions == null)
            {
                return;
            }

            foreach (var item in data.Questions)
            {
                QuestionsList.Add(item);
            }
        }
    }

    public class QuestionItem
    {
        public string? Question { get; set; }
        public List<string>? Answer { get; set; }
    }

    public class QuestionsData
    {
        public List<QuestionItem>? Questions { get; set; }
    }

}
