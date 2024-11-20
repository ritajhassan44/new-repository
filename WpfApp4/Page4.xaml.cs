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
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
        }
        Task_managementEntities task_ManagementEntities = new Task_managementEntities();
        public void refreshdatagrid1()
        {
            var emp = task_ManagementEntities.Tasks.Select(x => new
            {
                x.TaskID,
                x.Descriptions,
                x.Title,
                name = x.User.Email,
                email = x.User.Names
            }).ToList();
            Data_grid_tasks.ItemsSource = emp;
        }

        private void Save_button(object sender, RoutedEventArgs e)
        {

        }
    }
}
