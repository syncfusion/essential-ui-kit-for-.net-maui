using Syncfusion.Maui.DataForm;

namespace EssentialMAUIUIKit.Common
{
    public class ItemsSourceProvider : IDataFormSourceProvider
    {
        public object GetSource(string sourceName)
        {
            if (sourceName == "BusinessCountry")
            {
                List<string> list = new List<string>()
                {
                    "USA",
                    "Japan",
                    "India",
                    "China",
                    "UK",
                };

                return list;
            }

            if (sourceName == "BusinessState")
            {
                List<string> list = new List<string>()
                {
                    "New York",
                    "California",
                    "Texas",
                    "Florida",
                    "Washington",
                };

                return list;
            }

            if (sourceName == "State")
            {
                List<string> list = new List<string>()
    {
        "New York",
        "California",
        "Texas",
        "Florida",
        "Washington",
    };

                return list;
            }

            if (sourceName == "BusinessType")
            {
                List<string> list = new List<string>()
                {
                    "Sole Proprietorship",
                    "Partnership",
                    "Limited Partnership",
                    "Corporation",
                    "Limited Liability Company",
                    "Non-profit Organization",
                    "Cooperative",
                };

                return list;
            }

            return new List<string>();
        }
    }
}
