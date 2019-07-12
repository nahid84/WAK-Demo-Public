using System.Windows;

namespace WAK_Session_01_DesktopApp
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text))
                MessageBox.Show("Please type your name into the box");
            else
                MessageBox.Show($"Welcome {txtName.Text}");
        }
    }
}
