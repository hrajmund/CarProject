using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace CarProject
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        //static List<int> Scores = new List<int>();
        static List<Rectangle> Coins = new List<Rectangle>();
        static List<Rectangle> RoadBlocks = new List<Rectangle>();
        //static List<Rect> HitBoxes = new List<Rect>();

        bool goLeft, goRight;
        int speed = 12;
        int score = 0;
        int scorecount = 0;
        int faultcount = 0;
        int fault = 0;

        public GameWindow()
        {
            InitializeComponent();                       
            myCanvas.Focus();

            //CountReadIn();

            Coins.Add(C0);
            Coins.Add(C1);
            Coins.Add(C2);
            Coins.Add(C3);
            Coins.Add(C4);
            Coins.Add(C5);
            Coins.Add(C6);
            RoadBlocks.Add(R0);
            RoadBlocks.Add(R1);

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
        private void CoinHit(Rectangle player, Rectangle _collectible)
        {
            Rect CarHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, 1);
            Rect CollectibleHitBox = new Rect(Canvas.GetLeft(_collectible), Canvas.GetTop(_collectible), _collectible.Width, _collectible.Height);
            Rect BackBox = new Rect(Canvas.GetLeft(Back), Canvas.GetTop(Back), Back.Width, Back.Height);


            if (CarHitBox.IntersectsWith(CollectibleHitBox))
            {
                CollectibleHitBox.Height = 1;
                CollectibleHitBox.Width = 1;
                _collectible.Visibility = Visibility.Hidden;
                scorecount += 1;
                if (scorecount < 1)
                {
                    scorecount = 1;
                }
                myScore.Text = Convert.ToString(score + scorecount);
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
            for (int i = 0; i < RoadBlocks.Count; i++)
            {
                Canvas.SetTop(RoadBlocks[i], Canvas.GetTop(RoadBlocks[i]) + speed);
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
                CoinHit(car1, Coins[i]);                
            }
            for (int i = 0; i < RoadBlocks.Count; i++)
            {
                RoadBlockHit(car1, RoadBlocks[i]);                
            }
        }
        //private void CountReadIn()
        //{
        //    StreamReader sr = new StreamReader("index.txt");
        //    string line = sr.ReadLine();
        //    for (int i = 0; i < Convert.ToInt32(line); i++)
        //    {
        //        Scores[i] = 0;
        //    }
        //    count = Convert.ToInt32(line);
        //    Console.WriteLine(count);
        //    selectedIndex = Convert.ToInt32(line);
        //    Console.WriteLine(selectedIndex);
        //}
        private void RoadBlockRespawn(Rectangle C)
        {
            C.Visibility = Visibility.Visible;
            Random positionX = new Random();
            Random positionY = new Random();

            Canvas.SetTop(C, positionY.Next(30, 315));
            if (positionX.Next(1, 4) == 1)
            {
                Canvas.SetLeft(C, 518);
            }
            if (positionX.Next(1, 4) == 2)
            {
                Canvas.SetLeft(C, 609);
            }
            if (positionX.Next(1, 4) == 3)
            {
                Canvas.SetLeft(C, 693);
            }
        }
        private void RoadBlockHit(Rectangle player, Rectangle _collectible)
        {
            Rect CarHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, 1);
            Rect CollectibleHitBox = new Rect(Canvas.GetLeft(_collectible), Canvas.GetTop(_collectible), _collectible.Width, _collectible.Height);
            Rect BackBox = new Rect(Canvas.GetLeft(Back), Canvas.GetTop(Back), Back.Width, Back.Height);


            if (CarHitBox.IntersectsWith(CollectibleHitBox))
            {
                CollectibleHitBox.Height = 1;
                CollectibleHitBox.Width = 1;
                _collectible.Visibility = Visibility.Hidden;
                fault += 1;
                if (fault < 1)
                {
                    faultcount = 1;
                }
                myFaults.Text = Convert.ToString(fault + faultcount);
                Respawn(_collectible);
            }
            if (CollectibleHitBox.IntersectsWith(BackBox))
            {
                RoadBlockRespawn(_collectible);
            }
            if (fault == 3)
            {
                //StreamWriter sw = new StreamWriter("scoring.txt");
                //sw.WriteLine(count);
                //sw.WriteLine(selectedIndex);
                MessageBox.Show("You Died!");
                fault = 0;
                score = 0;
                Environment.Exit(0);
            }
        }
    }
}
