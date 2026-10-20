using Microsoft.Maui.Controls;
using Syncfusion.Maui.Chat;

namespace EssentialMAUIUIKit.Views.Chat
{
    /// <summary>
    /// Selects a chat message DataTemplate based on the runtime type of the message.
    /// </summary>
    public class ChatSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the template used to render <see cref="TextMessage"/> items.
        /// </summary>
        public DataTemplate? TextTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template used to render <see cref="ImageMessage"/> items.
        /// </summary>
        public DataTemplate? ImageTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template used to render audio message items.
        /// </summary>
        public DataTemplate? AudioTemplate { get; set; }

        /// <inheritdoc/>
        protected override DataTemplate? OnSelectTemplate(object item, BindableObject container)
        {
            return item switch
            {
                ImageMessage => this.ImageTemplate,
                _ => this.TextTemplate
            };
        }
    }
}
