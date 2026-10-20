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
                ""played"": ""17"",
                ""goldPoints"": ""+28"",
                ""points"": ""49"",
                ""matchResults"": [ ""#1C7E39"", ""#1C7E39"", ""#1C7E39"", ""#1C7E39"" ]
            },
            {
                ""imageIcon"": ""Leicester-City.png"",
                ""serialNumber"": ""2"",
                ""clubName"": ""LEI"",
                ""played"": ""17"",
                ""goldPoints"": ""+29"",
                ""points"": ""39"",
                ""matchResults"": [ ""#1C7E39"", ""#1C7E39"", ""#1C7E39"", ""#1C7E39"" ]
            },
            {
                ""imageIcon"": ""Manchester-City.png"",
                ""serialNumber"": ""3"",
                ""clubName"": ""MCI"",
                ""played"": ""17"",
                ""goldPoints"": ""+28"",
                ""points"": ""49"",
                ""matchResults"": [ ""#1C7E39"", ""#b2b8c2"", ""#1C7E39"", ""#ff4a4a"" ]
            },
            {
                ""imageIcon"": ""Chelsea.png"",
                ""serialNumber"": ""4"",
                ""clubName"": ""CHE"",
                ""played"": ""17"",
                ""goldPoints"": ""+6"",
                ""points"": ""29"",
                ""matchResults"": [ ""#ff4a4a"", ""#ff4a4a"", ""#1C7E39"", ""#ff4a4a"" ]
            },
            {
                ""imageIcon"": ""Tottenham-Hotspur.png"",
                ""serialNumber"": ""5"",
                ""clubName"": ""TOT"",
                ""played"": ""17"",
                ""goldPoints"": ""+8"",
                ""points"": ""26"",
                ""matchResults"": [ ""#1C7E39"", ""#1C7E39"", ""#ff4a4a"", ""#1C7E39"" ]
            },
            {
                ""imageIcon"": ""manchester-united-logo.png"",
                ""serialNumber"": ""6"",
                ""clubName"": ""MUN"",
                ""played"": ""17"",
                ""goldPoints"": ""+6"",
                ""points"": ""25"",
                ""matchResults"": [ ""#b2b8c2"", ""#b2b8c2"", ""#1C7E39"", ""#1C7E39"" ]
            },
            {
                ""imageIcon"": ""Sheffield-United.png"",
                ""serialNumber"": ""7"",
                ""clubName"": ""SHU"",
                ""played"": ""17"",
                ""goldPoints"": ""+5"",
                ""points"": ""25"",
                ""matchResults"": [ ""#b2b8c2"", ""#b2b8c2"", ""#ff4a4a"", ""#1C7E39"" ]
            },
            {
                ""imageIcon"": ""Wolverhampton-Wanderers.png"",
                ""serialNumber"": ""8"",
                ""clubName"": ""WOL"",
                ""played"": ""17"",
                ""goldPoints"": ""+3"",
                ""points"": ""24"",
                ""matchResults"": [ ""#1C7E39"", ""#b2b8c2"", ""#1C7E39"", ""#b2b8c2"" ]
            },
            {
                ""imageIcon"": ""Crystal-Palace.png"",
                ""serialNumber"": ""9"",
                ""clubName"": ""CRY"",
                ""played"": ""17"",
                ""goldPoints"": ""-4"",
                ""points"": ""23"",
                ""matchResults"": [ ""#ff4a4a"", ""#1C7E39"", ""#1C7E39"", ""#b2b8c2"" ]
            },
            {
                ""imageIcon"": ""Arsenal.png"",
                ""serialNumber"": ""10"",
                ""clubName"": ""ARS"",
                ""played"": ""17"",
                ""goldPoints"": ""-3"",
                ""points"": ""22"",
                ""matchResults"": [ ""#b2b8c2"", ""#b2b8c2"", ""#ff4a4a"", ""#1C7E39"" ]
            },
            {
                ""imageIcon"": ""Newcastle-United.png"",
                ""serialNumber"": ""11"",
                ""clubName"": ""NEW"",
                ""played"": ""17"",
                ""goldPoints"": ""-7"",
                ""points"": ""22"",
                ""matchResults"": [ ""#ff4a4a"", ""#b2b8c2"", ""#1C7E39"", ""#1C7E39"" ]
            },
            {
                ""imageIcon"": ""Burnley.png"",
                ""serialNumber"": ""12"",
                ""clubName"": ""BUR"",
                ""played"": ""17"",
                ""goldPoints"": ""-7"",
                ""points"": ""21"",
                ""matchResults"": [ ""#1C7E39"", ""#ff4a4a"", ""#ff4a4a"", ""#ff4a4a"" ]
            },
            {
                ""imageIcon"": ""Brighton-and-Hove-Albion.png"",
                ""serialNumber"": ""13"",
                ""clubName"": ""BHA"",
                ""played"": ""17"",
                ""goldPoints"": ""-4"",
                ""points"": ""20"",
                ""matchResults"": [ ""#ff4a4a"", ""#ff4a4a"", ""#1C7E39"", ""#b2b8c2"" ]
            },
            {
                ""imageIcon"": ""AFC-Bournemouth.png"",
                ""serialNumber"": ""14"",
                ""clubName"": ""BOU"",
                ""played"": ""17"",
                ""goldPoints"": ""-5"",
                ""points"": ""19"",
                ""matchResults"": [ ""#ff4a4a"", ""#ff4a4a"", ""#ff4a4a"", ""#ff4a4a"" ]
            },
            {
                ""imageIcon"": ""West-Ham-United.png"",
                ""serialNumber"": ""15"",
                ""clubName"": ""WHU"",
                ""played"": ""17"",
                ""goldPoints"": ""-9"",
                ""points"": ""19"",
                ""matchResults"": [ ""#ff4a4a"", ""#1C7E39"", ""#ff4a4a"", ""#ff4a4a"" ]
            },
            {
                ""imageIcon"": ""Everton.png"",
                ""serialNumber"": ""16"",
                ""clubName"": ""EVE"",
                ""played"": ""17"",
                ""goldPoints"": ""-9"",
                ""points"": ""18"",
                ""matchResults"": [ ""#ff4a4a"", ""#ff4a4a"", ""#ff4a4a"", ""#1C7E39"" ]
            },
            {
                ""imageIcon"": ""Aston-Villa.png"",
                ""serialNumber"": ""17"",
                ""clubName"": ""AVL"",
                ""played"": ""17"",
                ""goldPoints"": ""-7"",
                ""points"": ""15"",
                ""matchResults"": [ ""#b2b8c2"", ""#1C7E39"", ""#1C7E39"", ""#ff4a4a"" ]
            },
            {
                ""imageIcon"": ""southampton-football-club-vector-logo.png"",
                ""serialNumber"": ""18"",
                ""clubName"": ""SOU"",
                ""played"": ""17"",
                ""goldPoints"": ""-18"",
                ""points"": ""15"",
                ""matchResults"": [ ""#b2b8c2"", ""#1C7E39"", ""#1C7E39"", ""#ff4a4a"" ]
            },
            {
                ""imageIcon"": ""Norwich-City.png"",
                ""serialNumber"": ""19"",
                ""clubName"": ""NOR"",
                ""played"": ""17"",
                ""goldPoints"": ""-17"",
                ""points"": ""12"",
                ""matchResults"": [ ""#1C7E39"", ""#b2b8c2"", ""#ff4a4a"", ""#ff4a4a"" ]
            },
            {
                ""imageIcon"": ""Watford.png"",
                ""serialNumber"": ""20"",
                ""clubName"": ""WAT"",
                ""played"": ""17"",
                ""goldPoints"": ""-23"",
                ""points"": ""9"",
                ""matchResults"": [ ""#ff4a4a"", ""#ff4a4a"", ""#ff4a4a"", ""#b2b8c2"" ]
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
        public string? Played { get; set; }
        public string? GoldPoints { get; set; }
        public string? Points { get; set; }
        public List<string>? MatchResults { get; set; }
    }

}
