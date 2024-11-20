using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            refreshorshow();
        }
        Task_managementEntities task_ManagementEntities = new Task_managementEntities();
        public void refreshorshow()
        {
            var emp = task_ManagementEntities.Tasks.Select(x => new
            {
                x.TaskID,
                x.Title,
                x.Descriptions,
                Name = x.User.Names,
                Email = x.User.Email

            }).ToList();
            TaskDataGrid.ItemsSource = emp;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            if (TaskIdTextBox.Text == "" || TitleTextBox.Text == "" || DescriptionTextBox.Text == "" || StatusComboBox.Text == "" || EmailTextBox.Text == "")
            {
                MessageBox.Show("there is Missing Fields");
                return;
            }

            int id;
            try
            {
                id = int.Parse(TaskIdTextBox.Text);
            }
            catch (Exception exe)
            {
                MessageBox.Show("Id must be numbers");
                return;
            }

            var emp = task_ManagementEntities.Users.FirstOrDefault(x => x.Email == EmailTextBox.Text);

            if (emp == null)
            {
                MessageBox.Show("not correct user email");
                return;
            }


            Task task = new Task();
            task.Title = TitleTextBox.Text;
            task.Descriptions = DescriptionTextBox.Text;
            task.Statuss = StatusComboBox.Text;
            task.UserId = emp.UserID;
            task_ManagementEntities.Tasks.Add(task);
            task_ManagementEntities.SaveChanges();
            refreshorshow();

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskIdTextBox.Text == "" || TitleTextBox.Text == "" || DescriptionTextBox.Text == "" || StatusComboBox.Text == "" || EmailTextBox.Text == "")
            {
                MessageBox.Show("there is Missing Fields");
                return;
            }

            var emp = task_ManagementEntities.Users.FirstOrDefault(x => x.Email == EmailTextBox.Text);

            if (emp == null)
            {
                MessageBox.Show("not correct user email");
                return;
            }
            int id = int.Parse(TaskIdTextBox.Text);
            var emp1 = task_ManagementEntities.Tasks.FirstOrDefault(x => x.TaskID == id);
            if(emp1==null)
            {
                MessageBox.Show("wrong id");
                return;
            }
            if(StatusComboBox.Text=="")
            {
                MessageBox.Show("you must choose one");
            }
            emp1.Title = TitleTextBox.Text;
            emp1.Descriptions = DescriptionTextBox.Text;
            emp1.Statuss = StatusComboBox.Text;
         
            task_ManagementEntities.Tasks.AddOrUpdate(emp1);
            task_ManagementEntities.SaveChanges();
            refreshorshow();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(TaskIdTextBox.Text);
            var ta = task_ManagementEntities.Tasks.FirstOrDefault(x => x.TaskID == id);
            if (ta == null)
            {
                MessageBox.Show("invalid task ID, enter correct one");
                return;
            }


            task_ManagementEntities.Tasks.Remove(ta);
            task_ManagementEntities.SaveChanges();
            refreshorshow();

        }
    }
}
