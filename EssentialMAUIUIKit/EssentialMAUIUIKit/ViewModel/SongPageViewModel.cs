using System.Collections.ObjectModel;
using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class SongPageViewModel
    {
        public ObservableCollection<Song> SongsPageList { get; set; }

        public SongPageViewModel()
        {
            SongsPageList = new ObservableCollection<Song>();
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""songsPageList"": [
                {
                    ""songImage"": ""Songs_Image1.png"",
                    ""songname"": ""Santorini"",
                    ""composer"": ""Yanni""
                },
                {
                    ""songImage"": ""Songs_Image2.png"",
                    ""songname"": ""Orinoco flow"",
                    ""composer"": ""Enya""
                },
                {
                    ""songImage"": ""Songs_Image3.png"",
                    ""songname"": ""Thanksgiving"",
                    ""composer"": ""George Winston""
                },
                {
                    ""songImage"": ""Songs_Image4.png"",
                    ""songname"": ""The Voice Of Enigma "",
                    ""composer"": ""Enigma""
                },
                {
                    ""songImage"": ""Songs_Image5.png"",
                    ""songname"": ""Steam Forest"",
                    ""composer"": ""Andreas Vollenweider""
                },
                {
                    ""songImage"": ""Songs_Image6.png"",
                    ""songname"": ""In The Morning Light"",
                    ""composer"": ""Yanni""
                },
                {
                    ""songImage"": ""Songs_Image7.png"",
                    ""songname"": ""Children of the Sun"",
                    ""composer"": ""Dead Can Dance ""
                },
                {
                    ""songImage"": ""Songs_Image8.png"",
                    ""songname"": ""Winter into Spring"",
                    ""composer"": ""George Winston""
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<SongsData>(jsonData, options);
            var images = new List<string>() { "Songs_Image1.png", "Songs_Image2.png", "Songs_Image3.png", "Songs_Image4.png", "Songs_Image5.png", "Songs_Image6.png", "Songs_Image7.png", "Songs_Image8.png" };

            if (data?.SongsPageList == null)
            {
                return;
            }

            for (int i = 0; i < data.SongsPageList.Count; i++)
            {
                data.SongsPageList[i].SongImage = images[i];
                SongsPageList.Add(data.SongsPageList[i]);
            }
        }
    }

    public class Song
    {
        private string? songImage;
        public string SongImage
        {
            get { return App.ImageServerPath + songImage; }
            set { songImage = value; }
        }

        public string? SongName { get; set; }
        public string? Composer { get; set; }
    }

    public class SongsData
    {
        public List<Song>? SongsPageList { get; set; }
    }

}
