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

namespace ColorCatalog.Controls
{
    /// <summary>
    /// Interaction logic for CopyableTextBlock.xaml
    /// </summary>
    public partial class CopyableTextBlock : UserControl
    {
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(CopyableTextBlock), null);

        public CopyableTextBlock()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        private void CopyBtnClick(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(Text))
                Clipboard.SetText(Text);
        }
    }
}
