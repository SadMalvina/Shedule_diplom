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
    /// Логика взаимодействия для DepartmentShedule.xaml
    /// </summary>
    public partial class DepartmentShedule : Page
    {

        public string SatusDays(Shedule _currentShedule, int count)
        {
            var Abbreviavion = RaspisanieEntities1.GetContext().Shedule.ToList();

            if ((Abbreviavion.Exists(p => p.ID_statusDay == 1) && (Abbreviavion.Exists(p => p.Date == DateTime.Now.AddDays(-1)))) &&
                    (Abbreviavion.Exists(p => p.ID_statusDay == 1) && (Abbreviavion.Exists(p => p.Date == DateTime.Now.AddDays(-1)))))
            {
                return "В";
            }
            else if ((Abbreviavion.Exists(p => p.ID_statusDay == 1) && (Abbreviavion.Exists(p => p.Date == DateTime.Now.AddDays(-1)))) &&
                    (Abbreviavion.Exists(p => p.ID_statusDay == 2) && (Abbreviavion.Exists(p => p.Date == DateTime.Now.AddDays(-1)))))
            {
                return "В";
            }
            else if ((Abbreviavion.Exists(p => p.ID_statusDay == 2) && (Abbreviavion.Exists(p => p.Date == DateTime.Now.AddDays(-1)))) &&
                    (Abbreviavion.Exists(p => p.ID_statusDay == 1) && (Abbreviavion.Exists(p => p.Date == DateTime.Now.AddDays(-1)))))
            {
                return "Р";
            }
            else if ((Abbreviavion.Exists(p => p.ID_statusDay == 2) && (Abbreviavion.Exists(p => p.Date == DateTime.Now.AddDays(-1)))) &&
                    (Abbreviavion.Exists(p => p.ID_statusDay == 2) && (Abbreviavion.Exists(p => p.Date == DateTime.Now.AddDays(-1)))))
            {
                return "Р";
            }
            else
                count++;
            if (count == 3)
            {
                return "В";
                count = 0;
            }
            else
            {
                return "Р";
                count = 3;
            }

        }

        public int IdDays(TextBlock textBlock1)
        {
            if (textBlock1.Text == "Р") { return 1; } else
                if (textBlock1.Text == "В") { return 2; } else
                return 0;
        }

        public void Saved(Shedule _currentShedule)
        {
            if (_currentShedule.ID_record == 0) {
                RaspisanieEntities1.GetContext().Shedule.Add(_currentShedule);
                Console.WriteLine("Id_record ", _currentShedule.ID_record, " Id_employee ", _currentShedule.ID_employee, " Id_dayofweek ", _currentShedule.ID_dayOfWeek,
                    " Id_statusday ", _currentShedule.ID_statusDay, " date ", _currentShedule.Date, " id_chart ", _currentShedule.ID_chart);
            }

            try
            {
                RaspisanieEntities1.GetContext().SaveChanges();
                //MessageBox.Show("Информация сохранена!");
                Console.WriteLine("Id_record ", _currentShedule.ID_record.ToString(), " Id_employee ", _currentShedule.ID_employee, " Id_dayofweek ", _currentShedule.ID_dayOfWeek,
                    " Id_statusday ", _currentShedule.ID_statusDay, " date ", _currentShedule.Date, " id_chart ", _currentShedule.ID_chart);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private Shedule _currentShedule = new Shedule();
        private Departaments _currentShedule2 = new Departaments();
        private Employees _currentShedule3 = new Employees();
        public int count = 0;
        public string text = null;

        public DepartmentShedule(Shedule selectedShedule)
        {

            InitializeComponent();

            //DGridShedule.ItemsSource = RaspisanieEntities1.GetContext().Employees.ToList();


            DateTime today = DateTime.Today;
            //TextBlock MondayStatus = new TextBlock();
            // TextBlock Zagolovok = new TextBlock();
            //TextBlock SecondNameTextBlock = new TextBlock();
            TextBlock textBlock1 = new TextBlock();
            var Abbreviavion = RaspisanieEntities1.GetContext().Shedule.ToList();
            var Abbreviavion2 = RaspisanieEntities1.GetContext().Employees.ToList();
            var Abbreviavion3 = RaspisanieEntities1.GetContext().Departaments.ToList();
            foreach (var item3 in Abbreviavion3)
            {
                if (item3.ID_departament == 1)
                {
                    _currentShedule2.Departament_name = item3.Departament_name;
                    Zagolovok.Text = _currentShedule2.Departament_name;
                    

                }
            }


            //DataContext = _currentShedule;
            //Abbreviavion.Add(_currentShedule);

            foreach (var item2 in Abbreviavion2)
            {
                //TextBlock SecondNameTextBlock = null;
                _currentShedule3.Middle_name = item2.Middle_name;
                _currentShedule3 = item2;

                //FIO.Text = item2.Middle_name;


                foreach (var item in Abbreviavion)
                {
                    _currentShedule.ID_chart = item.ID_chart;
                    _currentShedule.ID_employee = item.ID_employee;

                    if (_currentShedule.ID_employee != item2.ID_employee)
                    {
                        _currentShedule.ID_employee = item2.ID_employee;
                        _currentShedule.ID_chart = item2.ID_chart;
                    }

                    SecondName.Text = _currentShedule3.Last_name;

                    if (today.DayOfWeek.ToString() == "Monday")
                    {

                        textBlock1.Text = DateTime.Now.ToString("M");
                        TextBlock MondayStatus = textBlock1;
                        _currentShedule.Date = today;
                        MondayStatus.Text = SatusDays(_currentShedule, count);
                        textBlock1.Text = SatusDays(_currentShedule, count);
                        //TextBlock MondayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 1;
                        Saved(_currentShedule);
                        if (_currentShedule.ID_record == 1) { count = 1; } /*



                        textBlock1.Text = DateTime.Now.AddDays(1).ToString("M");
                        TextBlock Tuesday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(1);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock TuesdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 2;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(2).ToString("M");
                        TextBlock Wednesday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(2);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock WednesdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 3;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(3).ToString("M");
                        TextBlock Thursday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(3);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock ThursdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 4;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(4).ToString("M");
                        TextBlock Friday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(4);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock FridayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 5;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(5).ToString("M");
                        TextBlock Saturday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(5);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock SaturdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 6;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(6).ToString("M");
                        TextBlock Sunday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(6);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock SundayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 7;
                        Saved(_currentShedule);
                    }

                    if (today.DayOfWeek.ToString() == "Tuesday")
                    {
                        textBlock1.Text = today.ToString("M");
                        _currentShedule.Date = today;
                        TextBlock Tuesday = textBlock1;
                        textBlock1.Text = SatusDays(_currentShedule, count);
                        //string st = SatusDays(_currentShedule);
                        TextBlock TuesdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 2;
                        Saved(_currentShedule);
                        if (_currentShedule.ID_record == 1) { count = 1; }

                        textBlock1.Text = DateTime.Now.AddDays(-1).ToString("M");
                        TextBlock Monday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(-1);
                        textBlock1.Text = SatusDays(_currentShedule, count);
                        TextBlock MondayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1); 
                        _currentShedule.ID_dayOfWeek = 1;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(1).ToString("M");
                        TextBlock Wednesday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(1);
                        textBlock1.Text = SatusDays(_currentShedule, count);
                        TextBlock WednesdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 3;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(2).ToString("M");
                        TextBlock Thursday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(2);
                        textBlock1.Text = SatusDays(_currentShedule, count);
                        TextBlock ThursdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 4;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(3).ToString("M");
                        TextBlock Friday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(3);
                        textBlock1.Text = SatusDays(_currentShedule, count);
                        TextBlock FridayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 5;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(4).ToString("M");
                        TextBlock Saturday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(4);
                        textBlock1.Text = SatusDays(_currentShedule, count);
                        TextBlock SaturdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 6;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(5).ToString("M");
                        TextBlock Sunday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(5);
                        textBlock1.Text = SatusDays(_currentShedule, count);
                        TextBlock SundayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 7;
                        Saved(_currentShedule);
                    }

                   /* if (today.DayOfWeek.ToString() == "Wednesday")
                    {
                        textBlock1.Text = today.ToString("M");
                        TextBlock Wednesday = textBlock1;
                        _currentShedule.Date = today;
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock WednesdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 3;
                        Saved(_currentShedule);
                        if (_currentShedule.ID_record == 1) { count = 1; }

                        textBlock1.Text = DateTime.Now.AddDays(-2).ToString("M");
                        TextBlock Monday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(-2);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock MondayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 1;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(-1).ToString("M");
                        TextBlock Tuesday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(-1);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock TuesdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 2;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(1).ToString("M");
                        TextBlock Thursday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(1);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock ThursdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 4;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(2).ToString("M");
                        TextBlock Friday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(2);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock FridayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 5;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(3).ToString("M");
                        TextBlock Saturday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(3);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock SaturdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 6;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(4).ToString("M");
                        TextBlock Sunday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(4);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock SundayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 7;
                        Saved(_currentShedule);
                    }

                    if (today.DayOfWeek.ToString() == "Thursday")
                    {
                        textBlock1.Text = today.ToString("M");
                        TextBlock Thursday = textBlock1;
                        _currentShedule.Date = today;
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock ThursdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 4;
                        Saved(_currentShedule);
                        if (_currentShedule.ID_record == 1) { count = 1; }

                        textBlock1.Text = DateTime.Now.AddDays(-3).ToString("M");
                        TextBlock Monday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(-3);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock MondayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 1;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(-2).ToString("M");
                        TextBlock Tuesday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(-2);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock TuesdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 2;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(-1).ToString("M");
                        TextBlock Wednesday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(-1);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock WednesdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 3;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(1).ToString("M");
                        TextBlock Friday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(1);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock FridayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 5;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(2).ToString("M");
                        TextBlock Saturday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(2);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock SaturdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 6;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(3).ToString("M");
                        TextBlock Sunday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(3);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock SundayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 7;
                        Saved(_currentShedule);
                    }

                    if (today.DayOfWeek.ToString() == "Friday")
                    {
                        textBlock1.Text = today.ToString("M");
                        TextBlock Friday = textBlock1;
                        _currentShedule.Date = today;
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock FridayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 5;
                        Saved(_currentShedule);
                        if (_currentShedule.ID_record == 1) { count = 1; }

                        textBlock1.Text = DateTime.Now.AddDays(-4).ToString("M");
                        TextBlock Monday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(-4);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock MondayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 1;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(-3).ToString("M");
                        TextBlock Tuesday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(-3);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock TuesdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 2;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(-2).ToString("M");
                        TextBlock Wednesday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(-2);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock WednesdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 3;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(-1).ToString("M");
                        TextBlock Thursday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(-1);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock ThursdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 4;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(1).ToString("M");
                        TextBlock Saturday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(1);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock SaturdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 6;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(2).ToString("M");
                        TextBlock Sunday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(2);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock SundayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 7;
                        Saved(_currentShedule);
                    }

                    if (today.DayOfWeek.ToString() == "Saturday")
                    {
                        textBlock1.Text = today.ToString("M");
                        TextBlock Saturday = textBlock1;
                        _currentShedule.Date = today;
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock SaturdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 6;
                        Saved(_currentShedule);
                        if (_currentShedule.ID_record == 1) { count = 1; }

                        textBlock1.Text = DateTime.Now.AddDays(-5).ToString("M");
                        TextBlock Monday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(-5);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock MondayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 1;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(-4).ToString("M");
                        TextBlock Tuesday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(-4);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock TuesdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 2;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(-3).ToString("M");
                        TextBlock Wednesday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(-3);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock WednesdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 3;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(-2).ToString("M");
                        TextBlock Thursday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(-2);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock ThursdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 4;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(-1).ToString("M");
                        TextBlock Friday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(-1);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock FridayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 5;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(1).ToString("M");
                        TextBlock Sunday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(1);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock SundayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 7;
                        Saved(_currentShedule);

                    }

                    if (today.DayOfWeek.ToString() == "Sunday")
                    {
                        textBlock1.Text = DateTime.Now.AddDays(7).ToString("M");
                        TextBlock Sunday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(7);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock SundayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 7;
                        Saved(_currentShedule);
                        if (_currentShedule.ID_record == 1) { count = 1; }

                        textBlock1.Text = DateTime.Now.AddDays(1).ToString("M");
                        TextBlock Monday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(1);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock MondayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 1;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(2).ToString("M");
                        TextBlock Tuesday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(2);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock TuesdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 2;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(3).ToString("M");
                        TextBlock Wednesday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(3);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock WednesdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 3;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(4).ToString("M");
                        TextBlock Thursday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(4);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock ThursdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 4;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(5).ToString("M");
                        TextBlock Friday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(5);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock FridayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 5;
                        Saved(_currentShedule);

                        textBlock1.Text = DateTime.Now.AddDays(6).ToString("M");
                        TextBlock Saturday = textBlock1;
                        _currentShedule.Date = DateTime.Now.AddDays(6);
                        textBlock1.Text = SatusDays(_currentShedule);
                        TextBlock SaturdayStatus = textBlock1;
                        _currentShedule.ID_statusDay = IdDays(textBlock1);
                        _currentShedule.ID_dayOfWeek = 6;
                        Saved(_currentShedule);
                    }*/
                        break;
                    }
                }

            }
        }

            private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                if (Visibility == Visibility.Visible)
                {
                    RaspisanieEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    DGridShedule.ItemsSource = RaspisanieEntities1.GetContext().Shedule.ToList();
                }
            }

        }
    }

