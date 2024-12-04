using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class FileExplorerViewModel
    {
        public ObservableCollection<FileExplorerFolder> FileExploreList { get; set; }

        public FileExplorerViewModel()
        {
            FileExploreList = new ObservableCollection<FileExplorerFolder>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""fileExploreList"": [
                { ""folderName"": ""Documents"", ""items"": ""8 Items"", ""dateTime"": ""28/11/2019  10:30 PM"" },
                { ""folderName"": ""Downloads"", ""items"": ""28 Items"", ""dateTime"": ""8/11/2019  11:20 PM"" },
                { ""folderName"": ""My Music"", ""items"": ""148 Items"", ""dateTime"": ""2/1/2020  8:44 AM"" },
                { ""folderName"": ""My Videos"", ""items"": ""48 Items"", ""dateTime"": ""21/9/2019  12:10 PM"" },
                { ""folderName"": ""Images"", ""items"": ""342 Items"", ""dateTime"": ""16/12/2019  6:45 PM"" },
                { ""folderName"": ""Data"", ""items"": ""21 Items"", ""dateTime"": ""18/11/2019  10:24 AM"" },
                { ""folderName"": ""Movies"", ""items"": ""12 Items"", ""dateTime"": ""25/11/2019  7:30 AM"" },
                { ""folderName"": ""Files"", ""items"": ""43 Items"", ""dateTime"": ""14/12/2019  11:30 PM"" }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<FileExplorerData>(jsonData, options);

            if (data?.FileExploreList == null)
            {
                return;
            }

            foreach (var folder in data.FileExploreList)
            {
                FileExploreList.Add(folder);
            }
        }
    }

    public class FileExplorerData
    {
        public List<FileExplorerFolder>? FileExploreList { get; set; }
    }

    public class FileExplorerFolder
    {
        public string? FolderName { get; set; }
        public string? Items { get; set; }
        public string? DateTime { get; set; }
    }

}
