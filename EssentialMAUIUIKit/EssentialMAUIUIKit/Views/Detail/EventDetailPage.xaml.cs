using System;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.Toolkit.Popup;

namespace EssentialMAUIUIKit.Views.Detail
{
    public partial class EventDetailPage : ContentView
    {
        public EventDetailPage()
        {
            InitializeComponent();
        }

        private void ResearchTapped(object sender, EventArgs e)
        {
            if (sender is View view)
            {
                researchPopup?.ShowRelativeToView(view, PopupRelativePosition.AlignBottom, 0, 10);
            }
        }

        private void HomeTapped(object sender, EventArgs e)
        {
            if (sender is View view)
            {
                homePopup?.ShowRelativeToView(view, PopupRelativePosition.AlignBottom, 0, 10);
            }
        }

        private void DraftTapped(object sender, EventArgs e)
        {
            if (sender is View view)
            {
                draftPopup?.ShowRelativeToView(view, PopupRelativePosition.AlignBottom, 0, 10);
            }
        }
    }
}