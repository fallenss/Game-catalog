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

namespace Курсилио
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
            Gridetsky.ItemsSource = Каталог_видеоигрEntities2.GetContext().Видеоигра.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            var a = Gridetsky.SelectedItems.Cast<Видеоигра>().ToList();
            Каталог_видеоигрEntities2.GetContext().Видеоигра.AddRange(a);
            Каталог_видеоигрEntities2.GetContext().SaveChanges();
            Gridetsky.ItemsSource = Каталог_видеоигрEntities2.GetContext().Видеоигра.ToList();
        }

        private void red_Click(object sender, RoutedEventArgs e)
        {
            Gridetsky.SelectedItems.Cast<Видеоигра>().ToList();
            Каталог_видеоигрEntities2.GetContext().SaveChanges();
            Gridetsky.ItemsSource = Каталог_видеоигрEntities2.GetContext().Видеоигра.ToList();
        }

        private void smert_Click(object sender, RoutedEventArgs e)
        {
            var a = Gridetsky.SelectedItems.Cast<Видеоигра>().ToList();
            Каталог_видеоигрEntities2.GetContext().Видеоигра.RemoveRange(a);
            Каталог_видеоигрEntities2.GetContext().SaveChanges();
            Gridetsky.ItemsSource = Каталог_видеоигрEntities2.GetContext().Видеоигра.ToList();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Вход a = new Вход();
            a.Show();
            Close();
        }

        private void rep_user_Click(object sender, RoutedEventArgs e)
        {
            report a = new report();
            a.Show();
        }

        private void rep_game_Click(object sender, RoutedEventArgs e)
        {
            report2 b = new report2();
            b.Show();
        }
    }
}
