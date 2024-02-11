using System.Diagnostics;
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

        private void login_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists("list.json"))
                {
                    using (StreamReader sr = new("list.json"))
                    {
                        string json = sr.ReadToEnd();
                        main_list = JsonSerializer.Deserialize<List<User>>(json);
                    }
                }

                string login = login_text_box.Text, password = pass_text_box.Password;
                if ((string.IsNullOrEmpty(login) || login == "Type your username") && (string.IsNullOrEmpty(password)))
                    MessageBox.Show("Enter your login and password first");
                else
                {
                    if (main_list == null)
                        MessageBox.Show("You are the first user in our databese, please go to the registration window");
                    else
                    {
                        User u = main_list.FirstOrDefault(x => x.Login == login && x.Password == password);
                        if (u == null)
                            MessageBox.Show("There is no user with such login and password, go to the registration if you need");
                        else
                        {
                            UserWindow uw = new(u);
                            uw.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pass_reset_ev(object sender, MouseButtonEventArgs e)
        {
            try
            {
                (sender as PasswordBox).Password = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void facebook_ev(object sender, MouseButtonEventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    Process pr = new();
                    pr.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                    pr.StartInfo.Arguments = "https://uk-ua.facebook.com/";
                    pr.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        private async void twitter_ev(object sender, MouseButtonEventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    Process pr = new();
                    pr.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                    pr.StartInfo.Arguments = "https://twitter.com/i/flow/login?input_flow_data=%7B%22requested_variant%22%3A%22eyJsYW5nIjoidWsifQ%3D%3D%22%7D";
                    pr.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        private async void google_ev(object sender, MouseButtonEventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    Process pr = new();
                    pr.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                    pr.StartInfo.Arguments = "https://accounts.google.com/v3/signin/identifier?continue=https%3A%2F%2Ftakeout.google.com%2F%3Fhl%3Dru&followup=https%3A%2F%2Ftakeout.google.com%2F%3Fhl%3Dru&hl=ru&ifkv=ASKXGp2fQLqnCXDi9VMkJET4cBT3EHR9jrdQDRK3z8lHlpn1yBP57B5lNK56wsilIdaIBZKirS-ISw&osid=1&passive=1209600&flowName=GlifWebSignIn&flowEntry=ServiceLogin&dsh=S-250838626%3A1707674176886875&theme=glif";
                    pr.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
    }
}