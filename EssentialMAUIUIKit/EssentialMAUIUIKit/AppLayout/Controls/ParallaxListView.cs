using System.Collections;

namespace EssentialMAUIUIKit.AppLayout.Controls
{
    public class ParallaxListView : ListView
    {
        public ParallaxListView()
            : base(ListViewCachingStrategy.RetainElement)
        {
            if (DeviceInfo.Platform != DevicePlatform.iOS)
            {
                this.ItemSelected += ParallaxListView_ItemSelected1;
            }
        }

        private void ParallaxListView_ItemSelected1(object? sender, SelectedItemChangedEventArgs e)
        {
            OnSelectionChanged(this, e);
        }

        public event EventHandler<SelectedItemChangedEventArgs>? SelectionChanged;

        public event EventHandler<ScrollChangedEventArgs>? ScrollChanged;

        public double WidthInPixel { get; set; }

        public static void OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ((ParallaxListView)sender)?.ScrollChanged?.Invoke((ParallaxListView)sender, e);
        }

        public static void OnSelectionChanged(object sender, SelectedItemChangedEventArgs e)
        {
            ParallaxListView listView = (ParallaxListView)sender;
            if (listView != null)
            {
                listView.SelectionChanged?.Invoke(sender, e);
                listView.SelectedItem = e?.SelectedItem;
                listView.SelectedItem = null;
            }
        }

        public static void OnSelectionChanged(object sender, int index)
        {
            if (sender is ParallaxListView)
            {
                var listView = sender as ParallaxListView;
                if (listView != null)
                {
                    OnSelectionChanged(sender, new SelectedItemChangedEventArgs(((IList)listView.ItemsSource)[index], index));
                }
            }
        }
    }

    public class ScrollChangedEventArgs : EventArgs
    {
        public ScrollChangedEventArgs(int position)
        {
            this.Position = position;
        }

        public int Position { get; set; }
    }
}
