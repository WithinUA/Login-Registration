using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Users_namespace;

namespace Login_Registration
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        string photo_path = string.Empty;
        List<User> list = null;

        public RegistrationWindow()
        {
            InitializeComponent();
            if (File.Exists("list.json"))
            {
                using (StreamReader sr = new("list.json"))
                {
                    string json = sr.ReadToEnd();
                    list = JsonSerializer.Deserialize<List<User>>(json);
                }
            }
        }

        private void load_photo(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif";
                if (ofd.ShowDialog() == true)
                {
                    photo_path = ofd.FileName;
                    ImageBrush brush = new ImageBrush();
                    brush.ImageSource = new BitmapImage(new Uri(photo_path));
                    photo_button.Background = brush;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                date_border.BorderBrush = Brushes.Red;
            }
        }

        private void check_data(object sender, RoutedEventArgs e)
        {
            try
            {
                bool is_all_ok = true;

                string fname = first_name_text_box.Text;
                string lname = last_name_text_box.Text;

                foreach (char el in id_text_box.Text)
                {
                    if (!char.IsDigit(el))
                    {
                        is_all_ok = false;
                        id_border.BorderBrush = Brushes.Red;
                    }
                }

                long id = long.TryParse(id_text_box.Text, out id) ? id : -1;

                if (!date_picker.SelectedDate.HasValue)
                {
                    is_all_ok = false;
                    date_border.BorderBrush = Brushes.Red;
                    MessageBox.Show("Input the birthdate");
                }

                DateTime date = new();
                try
                {
                    date = date_picker.SelectedDate.Value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    date_border.BorderBrush = Brushes.Red;
                }

                string login = login_text_box.Text;

                string password = password_text_box.Password;

                foreach (char el in age_text_box.Text)
                {
                    if (!char.IsDigit(el))
                    {
                        is_all_ok = false;
                        age_border.BorderBrush = Brushes.Red;
                    }
                }

                int age = int.TryParse(age_text_box.Text, out age) ? age : -1;

                if (male_radiobutton.IsChecked == false && female_radiobutton.IsChecked == false)
                {
                    is_all_ok = false;
                    MessageBox.Show("Select your gender");
                }

                string gender = "";
                if (male_radiobutton.IsChecked == true)
                    gender = "Male";
                if (female_radiobutton.IsChecked == true)
                    gender = "Female";


                string desc = desc_text_box.Text;

                if (is_all_ok)
                {
                    age_border.BorderBrush = Brushes.Green;
                    date_border.BorderBrush = Brushes.Green;
                    id_border.BorderBrush = Brushes.Green;

                    User el = new();
                    el.FirstName = fname;
                    el.LastName = lname;
                    el.Id = id;
                    el.BirthDate = date;
                    el.Login = login;
                    el.Password = password;
                    el.Gender = gender;
                    el.Age = age;
                    el.Description = desc;

                    if (!string.IsNullOrEmpty(photo_path))
                        el.PhotoPath = photo_path;
                    if (list == null)
                        list = new();
                    list.Add(el);

                    MessageBox.Show($"You have sucsessfully registered");

                    using (StreamWriter sw = new("list.json"))
                    {
                        string json = JsonSerializer.Serialize(list);
                        sw.WriteLine(json);
                    }

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                date_border.BorderBrush = Brushes.Red;
            }
        }

        private void check_login_ev(object sender, TextChangedEventArgs e)
        {
            string pattern = @"^[a-zA-Z0-9_]{0,15}$";
            User el = null;

            if (list != null)
            {
                el = list.FirstOrDefault(x => x.Login == (sender as TextBox).Text);
            }
            if (!Regex.IsMatch(login_text_box.Text, pattern) || el != null)
            {
                if (el == null)
                    MessageBox.Show("You can use only letters, numbers, \"_\" symbol and shorten than 15 characters");
                else
                    MessageBox.Show("User with this login already exists");
                login_border.BorderBrush = Brushes.Red;
                login_text_box.Text = "";
            }
            else
                login_border.BorderBrush= Brushes.Green;
        }

        private void check_password_ev(object sender, RoutedEventArgs e)
        {
            string pattern = @"^[a-zA-Z0-9_]{0,15}$";
            if (!Regex.IsMatch(password_text_box.Password, pattern))
            {
                MessageBox.Show("You can use only letters, numbers, \"_\" symbol and shorten than 15 characters");
                pass_border.BorderBrush = Brushes.Red;
                password_text_box.Password = "";
            }
            else
                pass_border.BorderBrush = Brushes.Green;
        }
    }
}
