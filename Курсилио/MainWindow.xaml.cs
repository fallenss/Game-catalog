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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Курсилио
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Каталог_видеоигрEntities2 dataEntities = new Каталог_видеоигрEntities2();
        public MainWindow()
        {
            InitializeComponent();
            Window_Loaded();
            //List<string> Genre = new List<string>() { "Action","JRPG","Anime","Racing","RPG"};
            //var allGenres = Genre;
            //allGenres.Insert(0, "Все жанры");
            DataContext = dataEntities;
            //ComboGenre.ItemsSource = allGenres;
            ComboGenre.SelectedIndex = 0;
            ComboRating.SelectedIndex = 0;
            var currentGames = Каталог_видеоигрEntities2.GetContext().Видеоигра.ToList();
            LViewGames.ItemsSource = currentGames;
            Find.PreviewMouseLeftButtonDown += Find_PreviewMouseLeftButtonDown;
        }
        private void Window_Loaded()
        {
            

        }
        private void Find_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Find.Text = "";
        }



        private void LViewGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (LViewGames.SelectedItem == null) return;
            Видеоигра в = LViewGames.SelectedItem as Видеоигра;
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

        private void Findless()
        {
            var abobus = Каталог_видеоигрEntities2.GetContext().Видеоигра.ToList();

            if (ComboRating.SelectedIndex > 0)
            {
                double rate = 0;
                switch (ComboRating.SelectedIndex)
                {
                    case 1:
                        {
                            rate = 1;
                        }
                        break;
                    case 2:
                        {
                            rate = 2;
                        }
                        break;
                    case 3:
                        {
                            rate = 3;
                        }
                        break;
                    case 4:
                        {
                            rate = 4;
                        }
                        break;
                    default:
                        rate = 0;
                        break;

                }
                abobus = abobus.Where(p => p.Рейтинг>rate).ToList();
            }

            if (ComboGenre.SelectedIndex > 0)
            {
                abobus = abobus.Where(p => p.Жанр.Contains(ComboGenre.Text)).ToList();
            }

            abobus = abobus.Where(p => p.Название.ToLower().Contains(Find.Text.ToLower())).ToList();
            
                
            LViewGames.ItemsSource = abobus;
        }

        private void Find_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Find.Text != "Поиск:")
            {
                Findless();
            }
        }

        private void OpenProfile_Click(object sender, RoutedEventArgs e)
        {
            Profile a = new Profile();
            a.Show();
            Close();
        }

        private void ComboGenre_GotFocus(object sender, RoutedEventArgs e)
        {
            Findless();
        }

        private bool IsToggle;
        private void Find_GotFocus(object sender, RoutedEventArgs e)
        {
   
        }

        private void Find_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            if (!IsToggle)
            {
                Thickness margin = Find.Margin;
                margin.Right += 1300;
                this.Find.BeginAnimation(FrameworkElement.MarginProperty, new ThicknessAnimation(margin, TimeSpan.FromSeconds(0.10)));
                IsToggle = true;
            }
            else
            {
                Thickness margin = Find.Margin;
                margin.Right -= 1300;
                this.Find.BeginAnimation(FrameworkElement.MarginProperty, new ThicknessAnimation(margin, TimeSpan.FromSeconds(0.2)));
                IsToggle = false;
            }
        }

        private void ComboRating_GotFocus(object sender, RoutedEventArgs e)
        {
            Findless();
        }
    }
}
