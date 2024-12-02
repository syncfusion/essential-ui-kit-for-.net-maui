using EssentialMAUIUIKit.Models.Navigation;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class AppUsageViewModel
    {
        public ObservableCollection<AppUsage> AppUsageList { get; set; }

        public AppUsageViewModel()
        {
            AppUsageList = new ObservableCollection<AppUsage>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""appUsagePageList"": [
                { ""appName"": ""Music"", ""progressBarValue"": ""40"", ""progressValue"": ""40%"", ""backgroundColor"": ""#837bff"" },
                { ""appName"": ""WhatsApp"", ""progressBarValue"": ""60"", ""progressValue"": ""60%"", ""backgroundColor"": ""#25d366"" },
                { ""appName"": ""Photos"", ""progressBarValue"": ""30"", ""progressValue"": ""30%"", ""backgroundColor"": ""#db7faa"" },
                { ""appName"": ""FaceBook"", ""progressBarValue"": ""50"", ""progressValue"": ""50%"", ""backgroundColor"": ""#3b5998"" },
                { ""appName"": ""Settings"", ""progressBarValue"": ""70"", ""progressValue"": ""70%"", ""backgroundColor"": ""#a8d35f"" },
                { ""appName"": ""Messages"", ""progressBarValue"": ""20"", ""progressValue"": ""20%"", ""backgroundColor"": ""#6c88ff"" },
                { ""appName"": ""Phone"", ""progressBarValue"": ""25"", ""progressValue"": ""25%"", ""backgroundColor"": ""#cf62e2"" },
                { ""appName"": ""Calendar"", ""progressBarValue"": ""10"", ""progressValue"": ""10%"", ""backgroundColor"": ""#ec5b76"" }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<AppUsageData>(jsonData, options);
            if (data?.AppUsagePageList == null)
            {
                return;
            }

            foreach (var appUsage in data.AppUsagePageList)
            {
                AppUsageList.Add(appUsage);
            }
        }
    }

    public class AppUsageData
    {
        public List<AppUsage>? AppUsagePageList { get; set; }
    }

}
