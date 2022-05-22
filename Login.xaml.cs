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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

    private void Entering_Click(object sender, RoutedEventArgs e)
        {
            var Users = RaspisanieeEntities.GetContext().Employees.ToList();

            bool Prov = false;
            foreach (var item in Users)
            {

                if ((Nikname.Text == item.NickName) && (Password.Password == item.Password))
                {
                    Prov = true;
                    Nicknamee.Nickname = Nikname.Text;
                    if (item.ID_status == 1)
                    {
                        Manager.MainFrame.Navigate(new WorkerMenu());
                    }
                    else if (item.ID_status == 2)
                    {
                        Manager.MainFrame.Navigate(new ChiefMenu());
                    }
                }
            }
                if (Prov == false)
                {
                    Manager.MainFrame.Navigate(new Login());
                    StringBuilder errors = new StringBuilder();

                    if (Prov == false)
                        errors.AppendLine("Ошибка 1: Некорректные логин или пароль!!");


                    if (errors.Length > 0)
                    {
                        MessageBox.Show(errors.ToString());
                        return;
                    }
                }
            }
        }
    }

