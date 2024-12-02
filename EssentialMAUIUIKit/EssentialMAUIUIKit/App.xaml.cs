namespace EssentialMAUIUIKit
{
    using EssentialMAUIUIKit.AppLayout;
    using EssentialMAUIUIKit.AppLayout.Views;
    using Microsoft.Maui;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
#if WINDOWS || MACCATALYST
            return new Window(new HomePageDesktopUI());
#else
            return new Window(new NavigationPage(new HomePageMobileUI()));
#endif
        }

        #region Properties

        public static string ImageServerPath { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";

        #endregion
    }
}
