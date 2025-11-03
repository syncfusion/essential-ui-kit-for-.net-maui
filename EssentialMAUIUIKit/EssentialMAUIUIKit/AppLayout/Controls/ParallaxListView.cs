using System.Collections;

namespace EssentialMAUIUIKit.AppLayout.Controls
{
    public class ParallaxListView : CollectionView
    {
        public ParallaxListView()
            : base()
        {
        }

        private void ParallaxListView_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            OnSelectionChanged(this, e.CurrentSelection);
        }

        public event EventHandler<ScrollChangedEventArgs>? ScrollChanged;

        public double WidthInPixel { get; set; }

        public static void OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ((ParallaxListView)sender)?.ScrollChanged?.Invoke((ParallaxListView)sender, e);
        }

        public static void OnSelectionChanged(object sender, object selectedItem)
        {
            if (sender is ParallaxListView)
            {
                var listView = sender as ParallaxListView;
                if (listView != null)
                {
                    OnSelectionChanged(sender, new SelectedItemChangedEventArgs(selectedItem, ((IList)listView.ItemsSource).IndexOf(selectedItem)));
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