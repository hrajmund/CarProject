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
        static List<Rectangle> Coins = new List<Rectangle>();
        static List<Rect> HitBoxes = new List<Rect>();

        bool goLeft, goRight;
        int speed = 12;
        int score = 0;
        int count = 0;
        public GameWindow()
        {
            InitializeComponent();
            myCanvas.Focus();

            Coins.Add(C0);
            Coins.Add(C1);
            Coins.Add(C2);
            Coins.Add(C3);
            Coins.Add(C4);
            Coins.Add(C5);
            Coins.Add(C6);
            //Coins.Add(C7);
            //Coins.Add(C8);

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(20);
            dispatcherTimer.Start();
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
        private void Hit(Rectangle player, Rectangle _collectible)
        {
            Rect CarHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, 1);
            Rect CollectibleHitBox = new Rect(Canvas.GetLeft(_collectible), Canvas.GetTop(_collectible), _collectible.Width, _collectible.Height);
            Rect BackBox = new Rect(Canvas.GetLeft(Back), Canvas.GetTop(Back), Back.Width, Back.Height);


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
                Respawn(_collectible);
            }
            if (CollectibleHitBox.IntersectsWith(BackBox))
            {
                Respawn(_collectible);
            }
        }
        private void Respawn(Rectangle C)
        {
            C.Visibility = Visibility.Visible;
            Random positionX = new Random();
            Random positionY = new Random();

            Canvas.SetTop(C, positionY.Next(30, 315));
            if (positionX.Next(1, 4) == 1)
            {
                Canvas.SetLeft(C, 534);
            }
            if (positionX.Next(1, 4) == 2)
            {
                Canvas.SetLeft(C, 625);
            }
            if (positionX.Next(1, 4) == 3)
            {
                Canvas.SetLeft(C, 708);
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Coins.Count; i++)
            {
                Canvas.SetTop(Coins[i], Canvas.GetTop(Coins[i]) + speed);
            }
            if (goLeft && Canvas.GetLeft(car1) > 515)
            {
                Canvas.SetLeft(car1, Canvas.GetLeft(car1) - speed);
            }
            if (goRight && Canvas.GetLeft(car1) + (car1.Width * 2) < Application.Current.MainWindow.Width - 450)
            {
                Canvas.SetLeft(car1, Canvas.GetLeft(car1) + speed);
            }

            for (int i = 0; i < Coins.Count; i++)
            {
                Hit(car1, Coins[i]);                
            }
        }
    }
}
