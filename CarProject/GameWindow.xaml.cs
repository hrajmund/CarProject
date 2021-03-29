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
using System.Windows.Threading;

namespace CarProject
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        bool goLeft, goRight;
        int coincounter = 10;
        int speed = 12;
        int score = 0;
        static List<Rectangle> _Coins = new List<Rectangle>();
        static List<CoinClass> _CC = new List<CoinClass>();
        public GameWindow()
        {
            InitializeComponent();
            myCanvas.Focus();
            for (int i = 0; i < coincounter; i++)
            {
                Coins();
                Hitbox(Coins());
                CoinClass cc = new CoinClass(Coins(), Hitbox(Coins()));
                _CC.Add(cc);
                Canvas.SetTop(Coins(), Canvas.GetTop(Coins()) + speed);
                Hit(car1, Coins());
            }

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(20);
            dispatcherTimer.Start();
        }
        private Rect Hitbox(Rectangle coin)
        {
            Rect CollectibleHitBox = new Rect(Canvas.GetLeft(coin), Canvas.GetTop(coin), coin.Width, coin.Height);
            return CollectibleHitBox;
        }
        private Rectangle Coins()
        {
            Random Left = new Random();
            Left.Next(400, 850);
            Random Top = new Random();
            
            Rectangle coin = new Rectangle()
            {
                Width = 32,
                Height = 32,
                Fill = Brushes.Black
            };
            myCanvas.Children.Add(coin);
            _Coins.Add(coin);
            Canvas.SetLeft(coin, Left.Next(400, 850));
            Canvas.SetTop(coin, Top.Next(10, 300));
            return coin;

        }
        private void Hit(Rectangle player, Rectangle _collectible)
        {
            Rect CarHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, 1);
            Rect CollectibleHitBox = new Rect(Canvas.GetLeft(_collectible), Canvas.GetTop(_collectible), _collectible.Width, _collectible.Height);
            int count = 0;
            if (CarHitBox.IntersectsWith(CollectibleHitBox))
            {
                CollectibleHitBox.Height = 1;
                CollectibleHitBox.Width = 1;
                _collectible.Visibility = Visibility.Hidden;
                count += 1;
                if (count < 1)
                {
                    count = 1;
                }
                myScore.Text = Convert.ToString(score + count);

            }
        }
        private void _Keydown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.A)
            {
                goLeft = true;
            }
            else if (e.Key == Key.D)
            {
                goRight = true;
            }

        }

        private void _Keyup(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.A)
            {
                goLeft = false;
            }
            else if (e.Key == Key.D)
            {
                goRight = false;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            //Canvas.SetTop(_Coins[i], Canvas.GetTop(_Coins[]) + speed);
            for (int i = 0; i < _CC.Count; i++)
            {
                
            }

            if (goLeft && Canvas.GetLeft(car1) > 350)
            {
                Canvas.SetLeft(car1, Canvas.GetLeft(car1) - speed);
            }
            if (goRight && Canvas.GetLeft(car1) + (car1.Width * 2) < Application.Current.MainWindow.Width - 300)
            {
                Canvas.SetLeft(car1, Canvas.GetLeft(car1) + speed);
            }
            Hit(car1, Coins());

            //Canvas.SetTop(_Coins[0], Canvas.GetTop(_Coins[0]) + speed);
            //for (int i = 0; i < _Coins.Count; i++)
            //{
            //    Canvas.SetTop(_Coins[i], Canvas.GetTop(_Coins[i]) + speed);
            //    Rect CarHitBox = new Rect(Canvas.GetLeft(car1), Canvas.GetTop(car1), car1.Width, 1);
            //    Rect CollectibleHitBox = new Rect(Canvas.GetLeft(_Coins[i]), Canvas.GetTop(_Coins[i]), _Coins[i].Width, _Coins[i].Height);
            //    int count = 0;
            //    if (CarHitBox.IntersectsWith(CollectibleHitBox))
            //    {
            //        CollectibleHitBox.Height = 1;
            //        CollectibleHitBox.Width = 1;
            //        _Coins[i].Visibility = Visibility.Hidden;
            //        count += 1;
            //        if (count < 1)
            //        {
            //            count = 1;
            //        }
            //        myScore.Text = Convert.ToString(score + count);

            //    }
            //}
            //Rect CarHitBox = new Rect(Canvas.GetLeft(car1), Canvas.GetTop(car1), car1.Width, 1);
            //Rect CollectibleHitBox = new Rect(Canvas.GetLeft(Coin), Canvas.GetTop(Coin), Coin.Width, Coin.Height);
            //Rect CollectibleHitBox2 = new Rect(Canvas.GetLeft(Coin2), Canvas.GetTop(Coin2), Coin2.Width, Coin2.Height);
            //Rect CollectibleHitBox3 = new Rect(Canvas.GetLeft(Coin3), Canvas.GetTop(Coin3), Coin3.Width, Coin3.Height);

            //if (CarHitBox.IntersectsWith(CollectibleHitBox2))
            //{
            //    CollectibleHitBox2.Height = 1;
            //    CollectibleHitBox2.Width = 1;
            //    Coin2.Visibility = Visibility.Hidden;
            //    count += 1;
            //    if (count < 1)
            //    {
            //        count = 1;
            //    }
            //    myScore.Text = Convert.ToString(score + count);

            //}
            //if (CarHitBox.IntersectsWith(CollectibleHitBox3))
            //{
            //    CollectibleHitBox3.Height = 1;
            //    CollectibleHitBox3.Width = 1;
            //    Coin3.Visibility = Visibility.Hidden;
            //    count += 1;
            //    if (count < 1)
            //    {
            //        count = 1;
            //    }
            //    myScore.Text = Convert.ToString(score + count);

            //}


        }
    }
}
