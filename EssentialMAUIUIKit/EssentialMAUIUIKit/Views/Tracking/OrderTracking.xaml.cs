using System;
using System.ComponentModel;

namespace EssentialMAUIUIKit.Views.Tracking
{
    public partial class OrderTracking : ContentView
    {
        private OrderTrackingViewModel? viewModel;

        public OrderTracking()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        private void OnLoaded(object? sender, EventArgs e)
        {
            if (BindingContext is OrderTrackingViewModel vm)
            {
                viewModel = vm;
                vm.PropertyChanged += OnViewModelPropertyChanged;
            }
        }

        private void OnUnloaded(object? sender, EventArgs e)
        {
            // Detach from the view model but do NOT dispose it: the
            // ContentView can be re-attached to the visual tree and the
            // view model may be reused. Disposal is the responsibility of
            // the host page (see <see cref="DetachBindingContext"/>).
            if (viewModel is not null)
            {
                viewModel.PropertyChanged -= OnViewModelPropertyChanged;
                viewModel = null;
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // Placeholder hook for any view-side reactions to VM changes.
            // The current UI is fully data-bound, so nothing to do here.
        }

        /// <summary>
        /// Detaches the binding context and disposes the view model if
        /// it implements <see cref="IDisposable"/>. Call this from the
        /// host page's teardown to release resources on the page's
        /// lifecycle, not on the view's transient detachment.
        /// </summary>
        public void DetachBindingContext()
        {
            if (BindingContext is IDisposable disposable)
            {
                disposable.Dispose();
            }

            BindingContext = null;
        }
    }
}