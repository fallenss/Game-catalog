using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        bool play = false;
        Видеоигра видеоигра { get; set; }
        public Game(Видеоигра p)
        {
            InitializeComponent();
            видеоигра = p;
            this.DataContext = видеоигра; // заполнение всех полей

            foreach (var amogus in Каталог_видеоигрEntities2.GetContext().лого) // подгрузка лого
            {
                if (amogus.id == p.картинка)
                {
                    MemoryStream mem = new MemoryStream(amogus.screen);
                   var bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.CacheOption = BitmapCacheOption.OnLoad;
                    bmp.StreamSource = mem;
                    bmp.EndInit();
                    bmp.Freeze();
                    Logo.Source = bmp;
                }
            }

            string put = @"D:\Archive\Illumination\3 круг\КПиЯП\Курсилио\Курсилио\Курсилио\Trailers\"+p.Название+".mp4"; // трейлер, ну, утром, по крайней мере
            Uri path = new Uri(put);
            Trailer.Source = path;

            foreach (var jitem in Каталог_видеоигрEntities2.GetContext().Оценённые) //Поиск оценки и закрашивание звёзд
            {
                if (jitem.Номер_Игры == info.id_game & jitem.ID_Пользователя == info.id_user)
                {
                    if (jitem.Оценка == 1)
                    {
                        Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb2.Style = (Style)Application.Current.Resources["BigFree"];
                        Jb3.Style = (Style)Application.Current.Resources["BigFree"];
                        Jb4.Style = (Style)Application.Current.Resources["BigFree"];
                        Jb5.Style = (Style)Application.Current.Resources["BigFree"];
                    }
                    else if (jitem.Оценка == 2)
                    {
                        Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb2.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb3.Style = (Style)Application.Current.Resources["BigFree"];
                        Jb4.Style = (Style)Application.Current.Resources["BigFree"];
                        Jb5.Style = (Style)Application.Current.Resources["BigFree"];
                    }
                    else if (jitem.Оценка == 3)
                    {
                        Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb2.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb3.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb4.Style = (Style)Application.Current.Resources["BigFree"];
                        Jb5.Style = (Style)Application.Current.Resources["BigFree"];
                    }
                    else if (jitem.Оценка == 4)
                    {
                        Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb2.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb3.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb4.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb5.Style = (Style)Application.Current.Resources["BigFree"];
                    }
                    else if (jitem.Оценка == 5)
                    {
                        Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb2.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb3.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb4.Style = (Style)Application.Current.Resources["BigFull"];
                        Jb5.Style = (Style)Application.Current.Resources["BigFull"];
                    }
                }
            }
        }
        public static BitmapImage ConvertFromByte(byte[] imageData)
        {
            if (imageData == null)
            {
                return null;
            }
            MemoryStream memorystream = new MemoryStream();

            memorystream.Write(imageData, 0, (int)imageData.Length);

            BitmapImage imgsource = new BitmapImage();

            imgsource.BeginInit();
            imgsource.StreamSource = memorystream;
            imgsource.EndInit();

            return imgsource;
        }
        private void ToFavor_Click(object sender, RoutedEventArgs e)
        {
            bool res = true;
            

            Избранное favor = new Избранное
            {
                Номер_игры = info.id_game,
                ID_пользователя = info.id_user,
            };
            foreach (var item in Каталог_видеоигрEntities2.GetContext().Избранное)
            {
                if (item.Номер_игры == favor.Номер_игры & item.ID_пользователя == favor.ID_пользователя)
                {
                    res = false;
                }

                if (res == false)
                {
                    MessageBox.Show("Так уже в избранном...", "Ошибка!");
                    break;
                }
            }
            if (res == true)
            {
                Каталог_видеоигрEntities2.GetContext().Избранное.Add(favor);
                Каталог_видеоигрEntities2.GetContext().SaveChanges();
                MessageBox.Show("Игра успешно добавлена в избранное, глянь профиль...", "Успешно!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void StopPlay_Click(object sender, RoutedEventArgs e)
        {
            Trail.Visibility = Visibility.Hidden;
            if (play == false)
            {
                Trailer.Play();
                play = true;
            }
            else
            {
                play = false;
                Trailer.Pause();
            }
        }

        private void Trailer_MediaEnded(object sender, RoutedEventArgs e)
        {
            Trailer.Stop();
            Trailer.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        //public void SS(Button a)
        //{
        //    if (a.Content.ToString() == Convert.ToString(1))
        //    {
        //        Jb1.Style = (Style)Application.Current.Resources["BigFull"];
        //    }
        //    else if (a.Content.ToString() == Convert.ToString(2))
        //    {
        //        Jb1.Style = (Style)Application.Current.Resources["BigFull"];
        //        Jb2.Style = (Style)Application.Current.Resources["BigFull"];
        //    }
        //    else if (a.Content.ToString() == Convert.ToString(3))
        //    {
        //        Jb1.Style = (Style)Application.Current.Resources["BigFull"];
        //        Jb2.Style = (Style)Application.Current.Resources["BigFull"];
        //        Jb3.Style = (Style)Application.Current.Resources["BigFull"];
        //    }
        //    else if (a.Content.ToString() == Convert.ToString(4))
        //    {
        //        Jb1.Style = (Style)Application.Current.Resources["BigFull"];
        //        Jb2.Style = (Style)Application.Current.Resources["BigFull"];
        //        Jb3.Style = (Style)Application.Current.Resources["BigFull"];
        //        Jb4.Style = (Style)Application.Current.Resources["BigFull"];
        //    }
        //    else if (a.Content.ToString() == Convert.ToString(5))
        //    {
        //        Jb1.Style = (Style)Application.Current.Resources["BigFull"];
        //        Jb2.Style = (Style)Application.Current.Resources["BigFull"];
        //        Jb3.Style = (Style)Application.Current.Resources["BigFull"];
        //        Jb4.Style = (Style)Application.Current.Resources["BigFull"];
        //        Jb5.Style = (Style)Application.Current.Resources["BigFull"];
        //    }
        //}

        private void Jb1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (((Button)e.OriginalSource).Content.ToString() == Convert.ToString(1))
            {
                Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                Jb2.Style = (Style)Application.Current.Resources["BigFree"];
                Jb3.Style = (Style)Application.Current.Resources["BigFree"];
                Jb4.Style = (Style)Application.Current.Resources["BigFree"];
                Jb5.Style = (Style)Application.Current.Resources["BigFree"];
            }
            else if (((Button)e.OriginalSource).Content.ToString() == Convert.ToString(2))
            {
                Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                Jb2.Style = (Style)Application.Current.Resources["BigFull"];
                Jb3.Style = (Style)Application.Current.Resources["BigFree"];
                Jb4.Style = (Style)Application.Current.Resources["BigFree"];
                Jb5.Style = (Style)Application.Current.Resources["BigFree"];
            }
            else if (((Button)e.OriginalSource).Content.ToString() == Convert.ToString(3))
            {
                Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                Jb2.Style = (Style)Application.Current.Resources["BigFull"];
                Jb3.Style = (Style)Application.Current.Resources["BigFull"];
                Jb4.Style = (Style)Application.Current.Resources["BigFree"];
                Jb5.Style = (Style)Application.Current.Resources["BigFree"];
            }
            else if (((Button)e.OriginalSource).Content.ToString() == Convert.ToString(4))
            {
                Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                Jb2.Style = (Style)Application.Current.Resources["BigFull"];
                Jb3.Style = (Style)Application.Current.Resources["BigFull"];
                Jb4.Style = (Style)Application.Current.Resources["BigFull"];
                Jb5.Style = (Style)Application.Current.Resources["BigFree"];
            }
            else if (((Button)e.OriginalSource).Content.ToString() == Convert.ToString(5))
            {
                Jb1.Style = (Style)Application.Current.Resources["BigFull"];
                Jb2.Style = (Style)Application.Current.Resources["BigFull"];
                Jb3.Style = (Style)Application.Current.Resources["BigFull"];
                Jb4.Style = (Style)Application.Current.Resources["BigFull"];
                Jb5.Style = (Style)Application.Current.Resources["BigFull"];
            }
        }


        private void Jb1_Click(object sender, RoutedEventArgs e)
        {
            bool res = true;


            Оценённые rate = new Оценённые
            {
                Номер_Игры = info.id_game,
                ID_Пользователя = info.id_user,
                Оценка = 1,
            };
            foreach (var jitem in Каталог_видеоигрEntities2.GetContext().Оценённые)
            {
                if (jitem.Номер_Игры == rate.Номер_Игры & jitem.ID_Пользователя == rate.ID_Пользователя)
                {
                    jitem.Оценка = rate.Оценка;
                    res = false;
                }
            }

                if (res == false)
                {
                    int rating = 0;
                    foreach (var item in Каталог_видеоигрEntities2.GetContext().Оценённые)
                    {
                        if (item.Номер_Игры == rate.Номер_Игры)
                        {
                            rating += item.Оценка;
                        }
                    }
                    double ratingTRUE = Convert.ToDouble(rating);
                    foreach (var item in Каталог_видеоигрEntities2.GetContext().Видеоигра)
                    {
                        if (item.Номер == rate.Номер_Игры)
                        {
                            item.Рейтинг = ratingTRUE / Convert.ToDouble(item.Количество_оценок);
                            ra.Text = Convert.ToString(Math.Round(item.Рейтинг,1));
                            ko.Text = Convert.ToString(item.Количество_оценок);
                            break;
                        }
                    }
                    MessageBox.Show("1Оценка отредактирована...", "Успешно!");
                }
            
            if (res == true)
            {
                Каталог_видеоигрEntities2.GetContext().Оценённые.Add(rate);
                int rating = 0;
                foreach (var item in Каталог_видеоигрEntities2.GetContext().Оценённые)
                {
                    if (item.Номер_Игры == rate.Номер_Игры)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                ratingTRUE += rate.Оценка;
                foreach (var item in Каталог_видеоигрEntities2.GetContext().Видеоигра)
                {
                    if (item.Номер == rate.Номер_Игры)
                    {
                        item.Рейтинг = ratingTRUE / (++item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }                    
                }              
                MessageBox.Show("Спасибо за оценку!", "Успешно!");
            }
            Каталог_видеоигрEntities2.GetContext().SaveChanges();
        }

        private void Jb2_Click(object sender, RoutedEventArgs e)
        {
            bool res = true;


            Оценённые rate = new Оценённые
            {
                Номер_Игры = info.id_game,
                ID_Пользователя = info.id_user,
                Оценка = 2,
            };
            foreach (var jitem in Каталог_видеоигрEntities2.GetContext().Оценённые)
            {
                if (jitem.Номер_Игры == rate.Номер_Игры & jitem.ID_Пользователя == rate.ID_Пользователя)
                {
                    jitem.Оценка = rate.Оценка;
                    res = false;
                }
            }

                if (res == false)
                {
                    int rating = 0;
                    foreach (var item in Каталог_видеоигрEntities2.GetContext().Оценённые)
                    {
                        if (item.Номер_Игры == rate.Номер_Игры)
                        {
                            rating += item.Оценка;
                        }
                    }
                    double ratingTRUE = Convert.ToDouble(rating);
                    foreach (var item in Каталог_видеоигрEntities2.GetContext().Видеоигра)
                    {
                        if (item.Номер == rate.Номер_Игры)
                        {
                        item.Рейтинг = ratingTRUE / Convert.ToDouble(item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                            break;
                        }
                    }
                    MessageBox.Show("2Оценка отредактирована...", "Успешно!");
                }
            
            if (res == true)
            {
                Каталог_видеоигрEntities2.GetContext().Оценённые.Add(rate);
                int rating = 0;
                foreach (var item in Каталог_видеоигрEntities2.GetContext().Оценённые)
                {
                    if (item.Номер_Игры == rate.Номер_Игры)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                ratingTRUE += rate.Оценка;
                foreach (var item in Каталог_видеоигрEntities2.GetContext().Видеоигра)
                {
                    if (item.Номер == rate.Номер_Игры)
                    {
                        item.Рейтинг = ratingTRUE / (++item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("Спасибо за оценку!", "Успешно!");
            }
            Каталог_видеоигрEntities2.GetContext().SaveChanges();
        }

        private void Jb3_Click(object sender, RoutedEventArgs e)
        {
            bool res = true;


            Оценённые rate = new Оценённые
            {
                Номер_Игры = info.id_game,
                ID_Пользователя = info.id_user,
                Оценка = 3,
            };
            foreach (var jitem in Каталог_видеоигрEntities2.GetContext().Оценённые)
            {
                if (jitem.Номер_Игры == rate.Номер_Игры & jitem.ID_Пользователя == rate.ID_Пользователя)
                {
                    jitem.Оценка = rate.Оценка;
                    res = false;
                }
            }

            if (res == false)
            {
                int rating = 0;
                foreach (var item in Каталог_видеоигрEntities2.GetContext().Оценённые)
                {
                    if (item.Номер_Игры == rate.Номер_Игры)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                foreach (var item in Каталог_видеоигрEntities2.GetContext().Видеоигра)
                {
                    if (item.Номер == rate.Номер_Игры)
                    {
                        item.Рейтинг = ratingTRUE / Convert.ToDouble(item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("2Оценка отредактирована...", "Успешно!");
            }

            if (res == true)
            {
                Каталог_видеоигрEntities2.GetContext().Оценённые.Add(rate);
                int rating = 0;
                foreach (var item in Каталог_видеоигрEntities2.GetContext().Оценённые)
                {
                    if (item.Номер_Игры == rate.Номер_Игры)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                ratingTRUE += rate.Оценка;
                foreach (var item in Каталог_видеоигрEntities2.GetContext().Видеоигра)
                {
                    if (item.Номер == rate.Номер_Игры)
                    {
                        item.Рейтинг = ratingTRUE / (++item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("Спасибо за оценку!", "Успешно!");
            }
            Каталог_видеоигрEntities2.GetContext().SaveChanges();
        }

        private void Jb4_Click(object sender, RoutedEventArgs e)
        {
            bool res = true;


            Оценённые rate = new Оценённые
            {
                Номер_Игры = info.id_game,
                ID_Пользователя = info.id_user,
                Оценка = 4,
            };
            foreach (var jitem in Каталог_видеоигрEntities2.GetContext().Оценённые)
            {
                if (jitem.Номер_Игры == rate.Номер_Игры & jitem.ID_Пользователя == rate.ID_Пользователя)
                {
                    jitem.Оценка = rate.Оценка;
                    res = false;
                }
            }

            if (res == false)
            {
                int rating = 0;
                foreach (var item in Каталог_видеоигрEntities2.GetContext().Оценённые)
                {
                    if (item.Номер_Игры == rate.Номер_Игры)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                foreach (var item in Каталог_видеоигрEntities2.GetContext().Видеоигра)
                {
                    if (item.Номер == rate.Номер_Игры)
                    {
                        item.Рейтинг = ratingTRUE / Convert.ToDouble(item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("2Оценка отредактирована...", "Успешно!");
            }

            if (res == true)
            {
                Каталог_видеоигрEntities2.GetContext().Оценённые.Add(rate);
                int rating = 0;
                foreach (var item in Каталог_видеоигрEntities2.GetContext().Оценённые)
                {
                    if (item.Номер_Игры == rate.Номер_Игры)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                ratingTRUE += rate.Оценка;
                foreach (var item in Каталог_видеоигрEntities2.GetContext().Видеоигра)
                {
                    if (item.Номер == rate.Номер_Игры)
                    {
                        item.Рейтинг = ratingTRUE / (++item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("Спасибо за оценку!", "Успешно!");
            }
            Каталог_видеоигрEntities2.GetContext().SaveChanges();
        }

        private void Jb5_Click(object sender, RoutedEventArgs e)
        {
            bool res = true;


            Оценённые rate = new Оценённые
            {
                Номер_Игры = info.id_game,
                ID_Пользователя = info.id_user,
                Оценка = 5,
            };
            foreach (var jitem in Каталог_видеоигрEntities2.GetContext().Оценённые)
            {
                if (jitem.Номер_Игры == rate.Номер_Игры & jitem.ID_Пользователя == rate.ID_Пользователя)
                {
                    jitem.Оценка = rate.Оценка;
                    res = false;
                }
            }

            if (res == false)
            {
                int rating = 0;
                foreach (var item in Каталог_видеоигрEntities2.GetContext().Оценённые)
                {
                    if (item.Номер_Игры == rate.Номер_Игры)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                foreach (var item in Каталог_видеоигрEntities2.GetContext().Видеоигра)
                {
                    if (item.Номер == rate.Номер_Игры)
                    {
                        item.Рейтинг = ratingTRUE / Convert.ToDouble(item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("2Оценка отредактирована...", "Успешно!");
            }

            if (res == true)
            {
                Каталог_видеоигрEntities2.GetContext().Оценённые.Add(rate);
                int rating = 0;
                foreach (var item in Каталог_видеоигрEntities2.GetContext().Оценённые)
                {
                    if (item.Номер_Игры == rate.Номер_Игры)
                    {
                        rating += item.Оценка;
                    }
                }
                double ratingTRUE = Convert.ToDouble(rating);
                ratingTRUE += rate.Оценка;
                foreach (var item in Каталог_видеоигрEntities2.GetContext().Видеоигра)
                {
                    if (item.Номер == rate.Номер_Игры)
                    {
                        item.Рейтинг = ratingTRUE / (++item.Количество_оценок);
                        ra.Text = Convert.ToString(Math.Round(item.Рейтинг, 1));
                        ko.Text = Convert.ToString(item.Количество_оценок);
                        break;
                    }
                }
                MessageBox.Show("Спасибо за оценку!", "Успешно!");
            }
            Каталог_видеоигрEntities2.GetContext().SaveChanges();
        }


    }
}
