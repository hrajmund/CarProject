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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<string> ProfileNames = new List<string>();        
        static List<Profile> AllProfile = new List<Profile>();
        //int selectedPlayer;
        //int profileScore;

        public MainWindow()
        {            
            InitializeComponent();
            ReadIn();
        }
        private void New_(object sender, RoutedEventArgs e)
        {
            //selectedPlayer = Players.SelectedIndex;
            //profileScore = AllProfile[Players.SelectedIndex].Score;
            //Index();
            GameWindow game = new GameWindow(); 
            game.Show();
            this.Close();
        }
        private void CreateProfile(object sender, RoutedEventArgs e)
        {
            int i = 1;
            AllProfile.Add(new Profile(NameText.Text, i));
            Players.Items.Add(NameText.Text);
            NameText.Clear();
            WriteProfiles();
        }
        private void WriteProfiles()
        {
            StreamWriter sw = new StreamWriter("profiles.txt", append:true);
            for (int i = 0; i < ProfileNames.Count; i++)
            {
                sw.WriteLine(AllProfile[i].Name + " " + AllProfile[i].Score);                
            }
            sw.Close();
        }
        private void ReadIn()
        {
            StreamReader sr = new StreamReader("profiles.txt");
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(' ');
                //AllProfile.Add(new Profile(line[0], Convert.ToInt32(line[1])));
                Players.Items.Add(line[0]);
            }
        }
        
        //private void Index()
        //{
        //    StreamWriter sw = new StreamWriter("index.txt");
        //    sw.WriteLine(AllProfile.Count);
        //    sw.WriteLine(profileScore);
        //    sw.WriteLine(selectedPlayer);
        //    sw.Close();
        //}
    }
}
