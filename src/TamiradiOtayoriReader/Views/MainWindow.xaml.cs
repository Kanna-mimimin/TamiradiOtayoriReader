using System.Windows;

namespace TamiradiOtayoriReader.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += (sender, e) => { this.DragMove(); };
        }

        private void ContentUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            ScrollViewer.ScrollToTop();
        }
    }
}
