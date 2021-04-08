using System.Windows;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnArabicToRoman_Click(object sender, RoutedEventArgs e)
        {
            Window1 nw1 = new Window1();
            nw1.Show();
        }

        private void btnRomanToArabic_Click(object sender, RoutedEventArgs e)
        {
            Window2 nw2 = new Window2();
            nw2.Show();
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
