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

        //protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        //{
        //    // Clear the background.
        //    Rect bg_rect = new Rect(0, 0, ActualWidth, ActualHeight);
        //    drawingContext.DrawRectangle(System.Windows.Media.Brushes.White, null, bg_rect);

        //    // Create the FormattedText.
        //    const double fontsize = 70;
        //    var font_family = new System.Windows.Media.FontFamily("Segoe");
        //    var typeface = new System.Windows.Media.Typeface("Segoe");
        //    var formatted_text =
        //        new System.Windows.Media.FormattedText("Outlined\nText",
        //            System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
        //            typeface, fontsize, System.Windows.Media.Brushes.Black);
        //    formatted_text.SetFontWeight(FontWeights.Bold);

        //    // Center horizontally.
        //    formatted_text.TextAlignment = TextAlignment.Center;

        //    // Pick an origin to center the text.
        //    Point origin = new Point(
        //        ActualWidth / 2,
        //        (ActualHeight - formatted_text.Height) / 2);

        //    // Convert the text into geometry.
        //    var geometry = formatted_text.BuildGeometry(origin);

        //    // Draw the geometry.
        //    var pen = new System.Windows.Media.Pen(System.Windows.Media.Brushes.Red, 2);
        //    drawingContext.DrawGeometry(System.Windows.Media.Brushes.Yellow, pen, geometry);
        //}
    }
}
