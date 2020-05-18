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

namespace Millionare
{
    /// <summary>
    /// Логика взаимодействия для Score.xaml
    /// </summary>
    public partial class Score : Window
    {
        public Score()
        {
            InitializeComponent();
            string path = "D:/Git/Millionare/Millionare/Millionare/bin/Debug/scores.txt";
            StreamReader reader = new StreamReader(path);
            Dictionary<string, int> scores = new Dictionary<string, int>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                scores.Add(line.Split(' ')[0], Convert.ToInt32(line.Split(' ')[1]));
            }
            scores = scores.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            StackPanel sPanel = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            int counter = 0;
            foreach (var pair in scores)
            {
                string text = (counter + 1).ToString() + " " + pair.Key + " " + pair.Value;
                TextBlock tb = new TextBlock()
                {
                    Text = text,
                };
                sPanel.Children.Add(tb);
                counter++;
                if (counter == 9)
                    break;
            }
            
            gMain.Children.Add(sPanel);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainMenu = new MainWindow();
            mainMenu.Show();
            scoreWindow.Close();
        }
    }
}
