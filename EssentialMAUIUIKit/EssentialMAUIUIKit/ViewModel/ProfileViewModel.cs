using System.Text.Json;

namespace EssentialMAUIUIKit
{
    public class ProfileViewModel
    {
        public Profile? Profile { get; set; }

        public ProfileViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            string jsonData = @"
        {
            ""headerImagePath"": ""Album2.png"",
            ""profileImage"": ""ProfileImage16.png"",
            ""backgroundImage"": ""Sky-Image.png"",
            ""profileName"": ""Lela Cortez"",
            ""designation"": ""Designer"",
            ""state"": ""San Francisco"",
            ""country"": ""CA"",
            ""about"": ""I am a UMN graduate (go Gophers!) and Minnesota native, but I am already loving my new home in the Golden Gate City! I cant wait to explore more of the great music scene here."",
            ""postsCount"": 8,
            ""followersCount"": 45,
            ""followingCount"": 45,
            ""interests"": [
                {
                    ""name"": ""Food"",
                    ""imagePath"": ""Recipe12.png""
                },
                {
                    ""name"": ""Travel"",
                    ""imagePath"": ""Album5.png""
                },
                {
                    ""name"": ""Music"",
                    ""imagePath"": ""ArticleImage7.jpg""
                },
                {
                    ""name"": ""Bags"",
                    ""imagePath"": ""Accessories.png""
                },
                {
                    ""name"": ""Market"",
                    ""imagePath"": ""PersonalCare.png""
                },
                {
                    ""name"": ""Food"",
                    ""imagePath"": ""Recipe12.png""
                },
                {
                    ""name"": ""Travel"",
                    ""imagePath"": ""Album5.png""
                },
                {
                    ""name"": ""Music"",
                    ""imagePath"": ""ArticleImage7.jpg""
                },
                {
                    ""name"": ""Bags"",
                    ""imagePath"": ""Accessories.png""
                },
                {
                    ""name"": ""Market"",
                    ""imagePath"": ""PersonalCare.png""
                }
            ],
            ""connections"": [
                {
                    ""name"": ""Rose King"",
                    ""imagePath"": ""ProfileImage7.png""
                },
                {
                    ""name"": ""Jeanette Bell"",
                    ""imagePath"": ""ProfileImage9.png""
                },
                {
                    ""name"": ""Lily Castro"",
                    ""imagePath"": ""ProfileImage10.png""
                },
                {
                    ""name"": ""Susie Moss"",
                    ""imagePath"": ""ProfileImage11.png""
                },
                {
                    ""name"": ""Rose King"",
                    ""imagePath"": ""ProfileImage7.png""
                },
                {
                    ""name"": ""Jeanette Bell"",
                    ""imagePath"": ""ProfileImage9.png""
                },
                {
                    ""name"": ""Lily Castro"",
                    ""imagePath"": ""ProfileImage10.png""
                },
                {
                    ""name"": ""Susie Moss"",
                    ""imagePath"": ""ProfileImage11.png""
                }
            ],
            ""pictures"": [
                {
                    ""imagePath"": ""ProfileImage8.png""
                },
                {
                    ""imagePath"": ""Album6.png""
                },
                {
                    ""imagePath"": ""ArticleImage4.jpg""
                },
                {
                    ""imagePath"": ""Recipe17.png""
                },
                {
                    ""imagePath"": ""ArticleImage5.jpg""
                },
                {
                    ""imagePath"": ""Mask.png""
                }
            ]
        }";

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Profile = JsonSerializer.Deserialize<Profile>(jsonData, options);
        }
    }

    public class Profile
    {
        private string? headerImagePath;
        private string? profileImage;
        private string? backgroundImage;
        public string? HeaderImagePath
        {
            get { return App.ImageServerPath + headerImagePath; }
            set { headerImagePath = value; }
        }

        public string? ProfileImage
        {
            get { return App.ImageServerPath + profileImage; }
            set { profileImage = value; }
        }

        public string BackgroundImage
        {
            get { return App.ImageServerPath + backgroundImage; }
            set { backgroundImage = value; }
        }

        public string? ProfileName { get; set; }
        public string? Designation { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? About { get; set; }
        public int PostsCount { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
        public List<Interest>? Interests { get; set; }
        public List<Connection>? Connections { get; set; }
        public List<Picture>? Pictures { get; set; }
    }

    public class Interest
    {
        private string? imagePath;
        public string? Name { get; set; }
        public string ImagePath
        {
            get { return App.ImageServerPath + imagePath; }
            set { imagePath = value; }
        }
    }

    public class Connection
    {
        private string? imagePath;
        public string? Name { get; set; }
        public string ImagePath
        {
            get { return App.ImageServerPath + imagePath; }
            set { imagePath = value; }
        }
    }

    public class Picture
    {
        private string? imagePath;
        public string ImagePath
        {
            get { return App.ImageServerPath + imagePath; }
            set { imagePath = value; }
        }
    }

}
