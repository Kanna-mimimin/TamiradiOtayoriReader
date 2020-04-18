using System.Windows;
using System.Windows.Controls;

namespace TamiradiOtayoriReader.Views
{
    /// <summary>
    /// Interaction logic for ConfigWindow
    /// </summary>
    public partial class ConfigWindow : UserControl
    {
        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void FileOpenButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Title = "ファイルを開く";
            dialog.Filter = "CSVファイル (*.csv)|*.csv";
            if (dialog.ShowDialog() == true)
            {
                this.CsvFilePathTextBox.Text = dialog.FileName;
            }
        }

        private void ImageOpenButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Title = "ファイルを開く";
            dialog.Filter = "画像ファイル (*.jpg, *.jpeg, *.gif, *.png) | *.jpg; *.jpeg; *.gif; *.png";
            if (dialog.ShowDialog() == true)
            {
                this.BackgroundImagePathTextBox.Text = dialog.FileName;
            }
        }
    }
}
