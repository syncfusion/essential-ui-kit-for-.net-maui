using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class DataTableViewModel
    {
        public ObservableCollection<DataTableList> DataTableLists { get; set; }

        public DataTableViewModel()
        {
            DataTableLists = new ObservableCollection<DataTableList>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        [
            {
                ""imageIcon"": ""Liverpool-FC.png"",
                ""serialNumber"": ""1"",
                ""clubName"": ""LIV"",
                ""goldPoints"": ""+28"",
                ""points"": ""49"",
                ""matchResults"": [ ""#7ed321"", ""#7ed321"", ""#7ed321"", ""#7ed321"", ""#7ed321"" ]
            },
            {
                ""imageIcon"": ""Leicester-City.png"",
                ""serialNumber"": ""2"",
                ""clubName"": ""LEI"",
                ""goldPoints"": ""+29"",
                ""points"": ""39"",
                ""matchResults"": [ ""#7ed321"", ""#7ed321"", ""#7ed321"", ""#7ed321"", ""#b2b8c2"" ]
            },
            {
                ""imageIcon"": ""Manchester-City.png"",
                ""serialNumber"": ""3"",
                ""clubName"": ""MCI"",
                ""goldPoints"": ""+28"",
                ""points"": ""49"",
                ""matchResults"": [ ""#7ed321"", ""#b2b8c2"", ""#7ed321"", ""#ff4a4a"", ""#7ed321"" ]
            },
            {
                ""imageIcon"": ""Chelsea.png"",
                ""serialNumber"": ""4"",
                ""clubName"": ""CHE"",
                ""goldPoints"": ""+6"",
                ""points"": ""29"",
                ""matchResults"": [ ""#ff4a4a"", ""#ff4a4a"", ""#7ed321"", ""#ff4a4a"", ""#ff4a4a"" ]
            },
            {
                ""imageIcon"": ""Tottenham-Hotspur.png"",
                ""serialNumber"": ""5"",
                ""clubName"": ""TOT"",
                ""goldPoints"": ""+8"",
                ""points"": ""26"",
                ""matchResults"": [ ""#7ed321"", ""#7ed321"", ""#ff4a4a"", ""#7ed321"", ""#7ed321"" ]
            },
            {
                ""imageIcon"": ""manchester-united-logo.png"",
                ""serialNumber"": ""6"",
                ""clubName"": ""MUN"",
                ""goldPoints"": ""+6"",
                ""points"": ""25"",
                ""matchResults"": [ ""#b2b8c2"", ""#b2b8c2"", ""#7ed321"", ""#7ed321"", ""#b2b8c2"" ]
            },
            {
                ""imageIcon"": ""Sheffield-United.png"",
                ""serialNumber"": ""7"",
                ""clubName"": ""SHU"",
                ""goldPoints"": ""+5"",
                ""points"": ""525"",
                ""matchResults"": [ ""#b2b8c2"", ""#b2b8c2"", ""#ff4a4a"", ""#7ed321"", ""#7ed321"" ]
            },
            {
                ""imageIcon"": ""Wolverhampton-Wanderers.png"",
                ""serialNumber"": ""8"",
                ""clubName"": ""WOL"",
                ""goldPoints"": ""+3"",
                ""points"": ""24"",
                ""matchResults"": [ ""#7ed321"", ""#b2b8c2"", ""#7ed321"", ""#b2b8c2"", ""#ff4a4a"" ]
            },
            {
                ""imageIcon"": ""Crystal-Palace.png"",
                ""serialNumber"": ""9"",
                ""clubName"": ""CRY"",
                ""goldPoints"": ""-4"",
                ""points"": ""23"",
                ""matchResults"": [ ""#ff4a4a"", ""#7ed321"", ""#7ed321"", ""#b2b8c2"", ""#b2b8c2"" ]
            },
            {
                ""imageIcon"": ""Arsenal.png"",
                ""serialNumber"": ""10"",
                ""clubName"": ""ARS"",
                ""goldPoints"": ""-3"",
                ""points"": ""22"",
                ""matchResults"": [ ""#b2b8c2"", ""#b2b8c2"", ""#ff4a4a"", ""#7ed321"", ""#ff4a4a"" ]
            },
            {
                ""imageIcon"": ""Newcastle-United.png"",
                ""serialNumber"": ""11"",
                ""clubName"": ""NEW"",
                ""goldPoints"": ""-7"",
                ""points"": ""22"",
                ""matchResults"": [ ""#ff4a4a"", ""#b2b8c2"", ""#7ed321"", ""#7ed321"", ""#ff4a4a"" ]
            },
            {
                ""imageIcon"": ""Burnley.png"",
                ""serialNumber"": ""12"",
                ""clubName"": ""BUR"",
                ""goldPoints"": ""-7"",
                ""points"": ""21"",
                ""matchResults"": [ ""#7ed321"", ""#ff4a4a"", ""#ff4a4a"", ""#ff4a4a"", ""#7ed321"" ]
            },
            {
                ""imageIcon"": ""Brighton-and-Hove-Albion.png"",
                ""serialNumber"": ""13"",
                ""clubName"": ""BHA"",
                ""goldPoints"": ""-4"",
                ""points"": ""20"",
                ""matchResults"": [ ""#ff4a4a"", ""#ff4a4a"", ""#7ed321"", ""#b2b8c2"", ""#b2b8c2"" ]
            },
            {
                ""imageIcon"": ""AFC-Bournemouth.png"",
                ""serialNumber"": ""14"",
                ""clubName"": ""BOU"",
                ""goldPoints"": ""-5"",
                ""points"": ""19"",
                ""matchResults"": [ ""#ff4a4a"", ""#ff4a4a"", ""#ff4a4a"", ""#ff4a4a"", ""#7ed321"" ]
            },
            {
                ""imageIcon"": ""West-Ham-United.png"",
                ""serialNumber"": ""15"",
                ""clubName"": ""WHU"",
                ""goldPoints"": ""-9"",
                ""points"": ""19"",
                ""matchResults"": [ ""#ff4a4a"", ""#7ed321"", ""#ff4a4a"", ""#ff4a4a"", ""#7ed321"" ]
            },
            {
                ""imageIcon"": ""Everton.png"",
                ""serialNumber"": ""16"",
                ""clubName"": ""EVE"",
                ""goldPoints"": ""-9"",
                ""points"": ""18"",
                ""matchResults"": [ ""#ff4a4a"", ""#ff4a4a"", ""#ff4a4a"", ""#7ed321"", ""#b2b8c2"" ]
            },
            {
                ""imageIcon"": ""Aston-Villa.png"",
                ""serialNumber"": ""17"",
                ""clubName"": ""AVL"",
                ""goldPoints"": ""-7"",
                ""points"": ""15"",
                ""matchResults"": [ ""#b2b8c2"", ""#7ed321"", ""#7ed321"", ""#ff4a4a"", ""#ff4a4a"" ]
            },
            {
                ""imageIcon"": ""southampton-football-club-vector-logo.png"",
                ""serialNumber"": ""18"",
                ""clubName"": ""SOU"",
                ""goldPoints"": ""-18"",
                ""points"": ""15"",
                ""matchResults"": [ ""#b2b8c2"", ""#7ed321"", ""#7ed321"", ""#ff4a4a"", ""#ff4a4a"" ]
            },
            {
                ""imageIcon"": ""Norwich-City.png"",
                ""serialNumber"": ""19"",
                ""clubName"": ""NOR"",
                ""goldPoints"": ""-17"",
                ""points"": ""12"",
                ""matchResults"": [ ""#7ed321"", ""#b2b8c2"", ""#ff4a4a"", ""#ff4a4a"", ""#b2b8c2"" ]
            },
            {
                ""imageIcon"": ""Watford.png"",
                ""serialNumber"": ""20"",
                ""clubName"": ""WAT"",
                ""goldPoints"": ""-23"",
                ""points"": ""9"",
                ""matchResults"": [ ""#ff4a4a"", ""#ff4a4a"", ""#ff4a4a"", ""#b2b8c2"", ""#ff4a4a"" ]
            }
        ]";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<List<DataTableList>>(jsonData, options);
            var imageIcons = new List<string>() { "Liverpool-FC.png", "Leicester-City.png", "Manchester-City.png", "Chelsea.png", "Tottenham-Hotspur.png", "manchester-united-logo.png", "Sheffield-United.png", "Wolverhampton-Wanderers.png", "Crystal-Palace.png", "Arsenal.png", "Newcastle-United.png", "Burnley.png", "Brighton-and-Hove-Albion.png", "AFC-Bournemouth.png", "West-Ham-United.png", "Everton.png", "Aston-Villa.png", "southampton-football-club-vector-logo.png", "Norwich-City.png", "Watford.png" };
            for (int i = 0; i < data?.Count; i++)
            {
                var image = imageIcons[i];
                data[i].ImageIcon = App.ImageServerPath + image;
                DataTableLists.Add(data[i]);
            }
        }
    }

    public class DataTableList
    {
        public string? ImageIcon { get; set; }
        public string? SerialNumber { get; set; }
        public string? ClubName { get; set; }
        public string? GoldPoints { get; set; }
        public string? Points { get; set; }
        public List<string>? MatchResults { get; set; }
    }

}
