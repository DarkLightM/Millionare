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
    public partial class Score : Window
    {
        public Score()
        {
            InitializeComponent();
            Logic logic = new Logic();
            string path = "D:/Git/Millionare/Millionare/Millionare/bin/Debug/scores.txt";
            Dictionary<string, int> scores = logic.FillTable(path);
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
