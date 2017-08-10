using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PoeOverlayMvvm.Utility;

namespace PoeOverlayMvvm.UserControls {
    /// <summary>
    /// Interaction logic for ItemsPanelView.xaml
    /// </summary>
    public partial class ItemsPanelView : UserControl {
        public ItemsPanelView() {
            InitializeComponent();
        }

        private void UIElement_OnMouseWheel(object sender, MouseWheelEventArgs e) {
            var scrollViewer = (ScrollViewer)sender;
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}
