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

namespace Shedule_diplom
{
    /// <summary>
    /// Логика взаимодействия для ChiefMenu.xaml
    /// </summary>
    public partial class ChiefMenu : Page
    {
        public ChiefMenu()
        {
            InitializeComponent();
        }

        private void DepartmentSheduleChief_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new DepartmentShedule());
        }

        private void MySheduleChief_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MyShedule());
        }

        private void MySalary_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Zarplata());
        }

        private void SalaryWorkers_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Zarplata());
        }
    }
}
