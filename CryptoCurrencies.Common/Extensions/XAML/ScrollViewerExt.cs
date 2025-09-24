using System.Windows;
using System.Windows.Input;

namespace CryptoCurrencies.Common.Extensions.XAML
{
    public static class ScrollViewerExt
    {
        public static readonly DependencyProperty BlockScrollOverElementProperty =
        DependencyProperty.RegisterAttached(
            "BlockScrollOverElement",
            typeof(UIElement),
            typeof(ScrollViewerExt),
            new PropertyMetadata(null, OnBlockScrollOverElementChanged));

        public static void SetBlockScrollOverElement(DependencyObject element, UIElement value)
        {
            element.SetValue(BlockScrollOverElementProperty, value);
        }

        public static UIElement GetBlockScrollOverElement(DependencyObject element)
        {
            return (UIElement)element.GetValue(BlockScrollOverElementProperty);
        }
        private static void OnBlockScrollOverElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is UIElement rootView)
            {
                rootView.PreviewMouseWheel -= Viewer_PreviewMouseWheel;
                if(e.NewValue is UIElement newElement)
                {
                    rootView.PreviewMouseWheel += Viewer_PreviewMouseWheel;
                    newElement.MouseWheel += NewElement_MouseWheel;
                }
                if(e.OldValue is UIElement oldElement)
                {
                    oldElement.MouseWheel -= NewElement_MouseWheel;
                }
            }
        }
        private static void NewElement_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            return;
        }
        private static void Viewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (sender is UIElement rootView)
            {
                var targetElement = GetBlockScrollOverElement(rootView);

                if (targetElement != null && targetElement.IsMouseOver)
                {
                    var newEvent = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp+1, e.Delta)
                    {
                        RoutedEvent = UIElement.MouseWheelEvent,
                        Source = targetElement,
                    };
                    targetElement.RaiseEvent(newEvent);
                    e.Handled = true;
                }
            }
        }
    }
}
