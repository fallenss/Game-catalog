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
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        public Profile()
        {
            InitializeComponent();
            Nickname.Text = "Никнейм: " + info.name;
            var currentGames = Каталог_видеоигрEntities2.GetContext().Видеоигра.ToList();
            currentGames.Clear();
            foreach (var amogus in Каталог_видеоигрEntities2.GetContext().Избранное)
            {
                if (info.id_user == amogus.ID_пользователя)
                {
                    info.id_game = amogus.Номер_игры;
                    foreach (var abobus in Каталог_видеоигрEntities2.GetContext().Видеоигра)
                    {
                        if (info.id_game == abobus.Номер)
                        {
                            currentGames.Add(abobus);
                        }
                    }
                }
            }
            
            LFavor.ItemsSource = currentGames;
        }

        private void LFavor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LFavor.SelectedItem == null) return;
            Видеоигра в = LFavor.SelectedItem as Видеоигра;
            info.id_game = в.Номер;
            Game aboba = new Game(new Видеоигра
            {
                Название = в.Название,
                Дата_выхода = в.Дата_выхода,
                Жанр = в.Жанр,
                Рейтинг = в.Рейтинг,
                Количество_оценок = в.Количество_оценок,
                Студия_разработчик = в.Студия_разработчик,
                Издатель = в.Издатель,
                Описание = в.Описание,
                Среднее_время_прохождения = в.Среднее_время_прохождения,
                Минимальные_системные_требования = в.Минимальные_системные_требования,
                Рекомендованные_системные_требования = в.Рекомендованные_системные_требования,
                картинка = в.картинка,
            });
            aboba.ShowDialog();
        }

        private void CloseProfile_Click(object sender, RoutedEventArgs e)
        {
            Вход ф = new Вход();
            ф.Show();
            Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            Close();
        }
    }
}
