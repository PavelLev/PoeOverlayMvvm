using System.Windows.Controls;
using System.Windows.Input;

namespace PoeOverlayMvvm.UserControls {
    /// <summary>
    /// Interaction logic for ItemSearchesPanelView.xaml
    /// </summary>
    public partial class ItemSearchesPanelView : UserControl {
        public ItemSearchesPanelView() {
            InitializeComponent();
        }

        private void UIElement_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e) {
            var scrollViewer = (ScrollViewer)sender;
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}
