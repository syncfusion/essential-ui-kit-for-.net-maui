using System.Collections.ObjectModel;
using System.Globalization;
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
                    ""songname"": ""National Anthem"",
                    ""composer"": ""Lana Del Rey"",
                    ""duration"": ""3:56""
                },
                {
                    ""songImage"": ""Songs_Image2.png"",
                    ""songname"": ""2 AM"",
                    ""composer"": ""Arizona Zervas"",
                    ""duration"": ""3:09""
                },
                {
                    ""songImage"": ""Songs_Image3.png"",
                    ""songname"": ""Baddest"",
                    ""composer"": ""2 chainz"",
                    ""duration"": ""4:45""
                },
                {
                    ""songImage"": ""Songs_Image4.png"",
                    ""songname"": ""True love"",
                    ""composer"": ""Kanye west"",
                    ""duration"": ""4:07""
                },
                {
                    ""songImage"": ""Songs_Image5.png"",
                    ""songname"": ""Bye Bye"",
                    ""composer"": ""Marshmello"",
                    ""duration"": ""3:09""
                },
                {
                    ""songImage"": ""Songs_Image6.png"",
                    ""songname"": ""Hands on you"",
                    ""composer"": ""Austin george"",
                    ""duration"": ""5:09""
                },
                {
                    ""songImage"": ""Songs_Image7.png"",
                    ""songname"": ""Thanksgiving"",
                    ""composer"": ""George Winston"",
                    ""duration"": ""3:45""
                },
                {
                    ""songImage"": ""Songs_Image8.png"",
                    ""songname"": ""Winter into Spring"",
                    ""composer"": ""George Winston"",
                    ""duration"": ""4:22""
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<SongsData>(jsonData, options);
            var images = new List<string>() { 
                "Songs_Image1.png", "Songs_Image2.png", "Songs_Image3.png", "Songs_Image4.png", 
                "Songs_Image5.png", "Songs_Image6.png", "Songs_Image7.png", "Songs_Image8.png" 
            };

            if (data?.SongsPageList == null)
            {
                return;
            }

            for (int i = 0; i < data.SongsPageList.Count; i++)
            {
                data.SongsPageList[i].SongImage = images[i];
                data.SongsPageList[i].IsPlaying = (i == 1);
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
        public string? Duration { get; set; }

        public bool IsPlaying { get; set; }
    }

    public class SongsData
    {
        public List<Song>? SongsPageList { get; set; }
    }


    public class PlayPauseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "||" : "▶";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}