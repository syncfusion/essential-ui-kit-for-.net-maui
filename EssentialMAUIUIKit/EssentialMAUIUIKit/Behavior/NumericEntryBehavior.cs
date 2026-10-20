using System.Text;

namespace EssentialMAUIUIKit
{
    /// <summary>
    /// Behavior that restricts an <see cref="Entry"/> to digits only. Any
    /// non-digit characters typed or pasted into the field are stripped on
    /// the fly, so the bound value never contains letters or symbols.
    /// </summary>
    public class NumericEntryBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += this.OnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= this.OnTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void OnTextChanged(object? sender, TextChangedEventArgs e)
        {
            if (sender is not Entry entry)
            {
                return;
            }

            string newText = e.NewTextValue ?? string.Empty;
            if (newText.Length == 0)
            {
                return;
            }

            // Keep cursor at a sensible position after we rewrite the text.
            int cursor = entry.CursorPosition;

            StringBuilder builder = new(newText.Length);
            foreach (char c in newText)
            {
                if (char.IsDigit(c))
                {
                    builder.Append(c);
                }
            }

            string sanitized = builder.ToString();
            if (!ReferenceEquals(sanitized, newText) && sanitized != newText)
            {
                entry.Text = sanitized;
                entry.CursorPosition = Math.Min(cursor, sanitized.Length);
            }
        }
    }
}
