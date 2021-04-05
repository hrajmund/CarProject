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
        static List<int> ProfileScores = new List<int>();
        public MainWindow()
        {            
            InitializeComponent();
            
            //Players.ItemsSource = ProfileNames;
        }
        private void New_(object sender, RoutedEventArgs e)
        {
            GameWindow game = new GameWindow();
            game.Show();
            this.Close();
        }
        private void CreateProfile(object sender, RoutedEventArgs e)
        {
            ProfileNames.Add(NameText.Text);
            Players.Items.Add(NameText.Text);
            NameText.Clear();
        }
        private void WriteProfiles()
        {
            StreamWriter sw = new StreamWriter("profiles.txt", append:true);
            for (int i = 0; i < ProfileNames.Count; i++)
            {

            }
        }

    }
}
