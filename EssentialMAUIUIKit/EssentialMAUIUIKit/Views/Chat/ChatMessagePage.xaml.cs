
using Microsoft.Maui.Controls;

namespace EssentialMAUIUIKit.Views.Chat
{
    public partial class ChatMessagePage : ContentView
    {
        public ChatMessagePage()
        {
            InitializeComponent();

            BindingContext = new ChatMessageViewModel();

            // On phones, hide the left recent-chats panel and show only the conversation
            if (DeviceInfo.Idiom == DeviceIdiom.Phone)
            {
                RecentChat.IsVisible = false;
                SeparatorBox.IsVisible = false;

                MainGrid.ColumnDefinitions.Clear();
                MainGrid.ColumnDefinitions.Add(
                    new ColumnDefinition
                    {
                        Width = GridLength.Star
                    });

                Grid.SetColumn(ChatGrid, 0);
            }
        }

        /// <summary>
        /// Handles the tap on the send (paper-plane) icon.
        /// On WinUI and MacCatalyst the entry does not flush its in-progress text
        /// to the bound <see cref="ChatMessageViewModel.MessageText"/> property
        /// until the entry loses focus, so tapping a sibling control runs the
        /// send command with stale (empty) text. Forcing <c>Unfocus()</c> on the
        /// entry commits the binding synchronously before the command runs.
        /// </summary>
        private void OnSendTapped(object? sender, TappedEventArgs e)
        {
            MessageEntry.Unfocus();

            if (BindingContext is ChatMessageViewModel viewModel
                && viewModel.SendMessageCommand?.CanExecute(null) == true)
            {
                viewModel.SendMessageCommand.Execute(null);
            }
        }
    }
}
