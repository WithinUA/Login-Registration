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
using System.Windows.Shapes;
using Users_namespace;

namespace Login_Registration
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        User user = null;
        public UserWindow()
        {
            InitializeComponent();
        }
        public UserWindow(User user)
        {
            InitializeComponent();
            this.user = user;

            if (user.PhotoPath != null)
            {
                photo_border.Background = new ImageBrush(new BitmapImage(new Uri(user.PhotoPath)));
            }
            hello_label.Content = $"Hello {user.Login}";
        }
    }
}
