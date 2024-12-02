namespace EssentialMAUIUIKit.Views.Catalog
{
    public partial class ProductHomePage : ContentView
    {
        public ProductHomePage()
        {
            InitializeComponent();
            this.bannerImage.Source = App.ImageServerPath + "Banner.png";
        }
    }
}