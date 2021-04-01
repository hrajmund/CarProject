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
        static List<CoinsWithHitBoxes> CoinsAndHitBoxes = new List<CoinsWithHitBoxes>();
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
            
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(20);
            dispatcherTimer.Start();
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
        private void Intersection(Rect CarHitBox, Rect CollectibleHitBox, Rectangle C)
        {
            CollectibleHitBox.Height = 1;
            CollectibleHitBox.Width = 1;
            C.Visibility = Visibility.Hidden;
            count += 1;
            if (count < 1)
            {
                count = 1;
            }
            myScore.Text = Convert.ToString(score + count);
        }
        private void Respawn(Rectangle C)
        {
            C.Visibility = Visibility.Visible;
            Random positionX = new Random();
            Random positionY = new Random();
            
            Canvas.SetTop(C, positionY.Next(30,315));
            if (positionX.Next(1,4) == 1)
            {
                Canvas.SetLeft(C, 534);
            }
            if (positionX.Next(1,4) == 2)
            {
                Canvas.SetLeft(C, 625);
            }
            if (positionX.Next(1,4) == 3)
            {
                Canvas.SetLeft(C, 708);
            }
        }
        private void Reach(Rectangle C, Rect Hitbox, Rect ReachHitBox)
        {
            if (Hitbox.IntersectsWith(ReachHitBox))
            {
                Respawn(C);
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
            Rect CarHitBox = new Rect(Canvas.GetLeft(car1), Canvas.GetTop(car1), car1.Width, 1);
            Rect ReachesHitBox = new Rect(Canvas.GetLeft(Reaches), Canvas.GetTop(Reaches), Reaches.Width, Reaches.Height);
            
            Rect CollectibleHitBox0 = new Rect(Canvas.GetLeft(C0), Canvas.GetTop(C0), C0.Width, C0.Height);
            Rect CollectibleHitBox1 = new Rect(Canvas.GetLeft(C1), Canvas.GetTop(C1), C1.Width, C1.Height);
            Rect CollectibleHitBox2 = new Rect(Canvas.GetLeft(C2), Canvas.GetTop(C2), C2.Width, C2.Height);
            Rect CollectibleHitBox3 = new Rect(Canvas.GetLeft(C3), Canvas.GetTop(C3), C3.Width, C3.Height);
            Rect CollectibleHitBox4 = new Rect(Canvas.GetLeft(C4), Canvas.GetTop(C4), C4.Width, C4.Height);
            
            if (CarHitBox.IntersectsWith(CollectibleHitBox0))
            {
                Intersection(CarHitBox, CollectibleHitBox0, C0);
                Respawn(C0);
                //Reach(C0, CollectibleHitBox0);
            }
            if (CarHitBox.IntersectsWith(CollectibleHitBox1))
            {
                Intersection(CarHitBox, CollectibleHitBox1, C1);
                Respawn(C1);
            }
            if (CarHitBox.IntersectsWith(CollectibleHitBox2))
            {
                Intersection(CarHitBox, CollectibleHitBox2, C2);
                Respawn(C2);
            }
            if (CarHitBox.IntersectsWith(CollectibleHitBox3))
            {
                Intersection(CarHitBox, CollectibleHitBox3, C3);
                Respawn(C3);
            }
            if (CarHitBox.IntersectsWith(CollectibleHitBox4))
            {
                Intersection(CarHitBox, CollectibleHitBox4, C4);
                Respawn(C4);
            }

        }
    }
}
