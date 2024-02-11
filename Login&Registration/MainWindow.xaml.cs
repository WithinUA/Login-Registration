using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Users_namespace;

namespace Login_Registration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> main_list = null;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void open_reg_window_ev(object sender, RoutedEventArgs e)
        {
            RegistrationWindow regwin = new();
            regwin.ShowDialog();
        }

        private void clear_content_ev(object sender, MouseButtonEventArgs e)
        {
            try
            {
                (sender as TextBox).Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}