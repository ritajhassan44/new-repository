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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Task_managementEntities task_ManagementEntities = new Task_managementEntities();
            var emp = task_ManagementEntities.Users.Where(s => s.Email == EmailTextBox.Text && s.Passwords == PasswordBox.Text).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text) || string.IsNullOrWhiteSpace(PasswordBox.Text))
            {
                MessageBox.Show("requird");
                return;
            }
            else if (emp == null)
            {
                MessageBox.Show("email not correct or not found");
                return;
            }
            else if (emp.Passwords != PasswordBox.Text)
            {
                MessageBox.Show("password not correct");
                return;
            }
            else
            {
                if (emp != null)
                {
                    if (emp.Roles == "Manager")
                    {
                        MessageBox.Show("Login succsessfully");
                        Page2 page2 = new Page2();
                        this.NavigationService.Navigate(page2);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Login succsessfully");

                    Page3 page3 = new Page3();
                    this.NavigationService.Navigate(page3);
                }
            }
        }

    }
}
