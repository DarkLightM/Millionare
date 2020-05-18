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
    public partial class MainGame : Window
    {
        int count = 1;
        public MainGame()
        {
            InitializeComponent();
            FillScores();
            FillQuestion(count);
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string text = button.Content.ToString();
            List<string> trueAnswers = FillTrueAnswers("D:/Git/Millionare/Millionare/Millionare/bin/Debug/trueAnswers.txt");
            if ((text.Equals(trueAnswers[count - 1]) && count != trueAnswers.Count) || (bool)aegis.IsChecked)
            {
                count++;
                FillQuestion(count);
                MessageBox.Show("Ты прав");
            }
            else if (count == trueAnswers.Count)
            {
                MessageBox.Show("Поздравляю, ты выйграл миллион");
                EndGame();
            }
            else
                EndGame();
        }

        public void FillScores()
        {
            StreamReader reader = new StreamReader("D:/Git/Millionare/Millionare/Millionare/bin/Debug/money.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                TextBlock tb = new TextBlock()
                {
                    Text = line,
                    Margin = new Thickness(5, 0, 0, 5),
                };
                scorePanel.Children.Add(tb);
            }
        }

        public void FillQuestion(int number)
        {
            Dictionary<string, string[]> questions = FillDictionary("D:/Git/Millionare/Millionare/Millionare/bin/Debug/questions.txt");
            string check = number.ToString() + ".";
            foreach (var pair in questions)
            {
                if (pair.Key.Contains(check))
                {
                    questionBlock.Text = pair.Key;
                    b1.Content = pair.Value[0];
                    b2.Content = pair.Value[1];
                    b3.Content = pair.Value[2];
                    b4.Content = pair.Value[3];
                }
            }
        }

        public Dictionary<string, string[]> FillDictionary(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line;
            Dictionary<string, string[]> result = new Dictionary<string, string[]>();
            while ((line = reader.ReadLine()) != null)
            {
                string[] arr = line.Split('?');
                result.Add(arr[0], arr[1].Split('_'));
            }
            return result;
        }

        public List<string> FillTrueAnswers(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line;
            List<string> trueAnswers = new List<string>();
            while ((line = reader.ReadLine()) != null)
            {
                trueAnswers.Add(line);
            }
            return trueAnswers;
        }

        public void EndGame()
        {
            MainWindow mainMenu = new MainWindow();
            mainMenu.Show();
            mainGame.Close();
        }

        private void Aegis_Checked(object sender, RoutedEventArgs e)
        {
            scorePanel.Children.Remove(aegis);
        }

        private void Half_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
