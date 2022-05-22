using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для DepartmentShedule.xaml
    /// </summary>
    /// 

   

    public partial class DepartmentShedule : Page
    {
        public Shedule _currentShedule = new Shedule();

        public DepartmentShedule()
        {
            InitializeComponent();

            var dt = DateTime.Now;
            var cal = new GregorianCalendar();
            var weekNumber = cal.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            var daytoday = DateTime.Today.DayOfWeek.ToString();

            var Emp = RaspisanieeEntities.GetContext().Shedule.ToList();
            foreach (var item in Emp)
            {
                _currentShedule.ID_employee = item.ID_employee;
                if (daytoday != "Sunday")
                {
                    if (item.ID_employee == _currentShedule.ID_employee && item.NumberOfWeek == null && item.NumberOfWeek != weekNumber)
                    {
                        foreach (var item2 in Emp)
                        {
                            if (item2.ID_employee == _currentShedule.ID_employee && item2.NumberOfWeek == weekNumber - 1)
                            {
                                if (item2.ID_status_Saturday == 1 && item2.ID_status_Sunday == 1)
                                {
                                    Pn.Text = "В";
                                    Vt.Text = "В";
                                    Sr.Text = "Р";
                                    Cht.Text = "Р";
                                    Pt.Text = "В";
                                    Sb.Text = "В";
                                    _currentShedule.ID_status_Saturday = 2;
                                    Vs.Text = "Р";
                                    _currentShedule.ID_status_Sunday = 1;

                                }
                                else if (item2.ID_status_Saturday == 1 && item2.ID_status_Sunday == 2)
                                {
                                    Pn.Text = "В";
                                    Vt.Text = "Р";
                                    Sr.Text = "Р";
                                    Cht.Text = "В";
                                    Pt.Text = "В";
                                    Sb.Text = "Р";
                                    _currentShedule.ID_status_Saturday = 1;
                                    Vs.Text = "Р";
                                    _currentShedule.ID_status_Sunday = 1;

                                }
                                else if (item2.ID_status_Saturday == 2 && item2.ID_status_Sunday == 1)
                                {
                                    Pn.Text = "Р";
                                    Vt.Text = "В";
                                    Sr.Text = "В";
                                    Cht.Text = "Р";
                                    Pt.Text = "Р";
                                    Sb.Text = "В";
                                    _currentShedule.ID_status_Saturday = 2;
                                    Vs.Text = "В";
                                    _currentShedule.ID_status_Sunday = 2;

                                }
                                else if (item2.ID_status_Saturday == 2 && item2.ID_status_Sunday == 2)
                                {
                                    Pn.Text = "Р";
                                    Vt.Text = "Р";
                                    Sr.Text = "В";
                                    Cht.Text = "В";
                                    Pt.Text = "Р";
                                    Sb.Text = "Р";
                                    _currentShedule.ID_status_Saturday = 1;
                                    Vs.Text = "В";
                                    _currentShedule.ID_status_Sunday = 2;
                                }
                            }
                        }
                        _currentShedule.NumberOfWeek = weekNumber;
                        _currentShedule.ID_chart = item.ID_chart;

                        //здесь должно быть сохранение в БД
                    }
                }
                else
                {
                    if (item.ID_employee == _currentShedule.ID_employee && item.NumberOfWeek == weekNumber)
                    {
                        if (item.ID_status_Saturday == 1 && item.ID_status_Sunday == 1)
                        {
                            Pn.Text = "В";
                            Vt.Text = "В";
                            Sr.Text = "Р";
                            Cht.Text = "Р";
                            Pt.Text = "В";
                            Sb.Text = "В";
                            _currentShedule.ID_status_Saturday = 2;
                            Vs.Text = "Р";
                            _currentShedule.ID_status_Sunday = 1;

                        }
                        else if (item.ID_status_Saturday == 1 && item.ID_status_Sunday == 2)
                        {
                            Pn.Text = "В";
                            Vt.Text = "Р";
                            Sr.Text = "Р";
                            Cht.Text = "В";
                            Pt.Text = "В";
                            Sb.Text = "Р";
                            _currentShedule.ID_status_Saturday = 1;
                            Vs.Text = "Р";
                            _currentShedule.ID_status_Sunday = 1;

                        }
                        else if (item.ID_status_Saturday == 2 && item.ID_status_Sunday == 1)
                        {
                            Pn.Text = "Р";
                            Vt.Text = "В";
                            Sr.Text = "В";
                            Cht.Text = "Р";
                            Pt.Text = "Р";
                            Sb.Text = "В";
                            _currentShedule.ID_status_Saturday = 2;
                            Vs.Text = "В";
                            _currentShedule.ID_status_Sunday = 2;

                        }
                        else if (item.ID_status_Saturday == 2 && item.ID_status_Sunday == 2)
                        {
                            Pn.Text = "Р";
                            Vt.Text = "Р";
                            Sr.Text = "В";
                            Cht.Text = "В";
                            Pt.Text = "Р";
                            Sb.Text = "Р";
                            _currentShedule.ID_status_Saturday = 1;
                            Vs.Text = "В";
                            _currentShedule.ID_status_Sunday = 2;
                        }
                    }
                }
            }
        }

            private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                if (Visibility == Visibility.Visible)
                {
                    RaspisanieeEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    DGridShedule.ItemsSource = RaspisanieeEntities.GetContext().Shedule.ToList();
                }
            }

        }
    }


