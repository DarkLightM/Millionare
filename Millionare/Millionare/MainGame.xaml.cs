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
        Dictionary<string, string> numberToMoney = new Dictionary<string, string>();
        public MainGame()
        {
            InitializeComponent();
            FillProgress();
            FillQuestion(count);
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            Logic logic = new Logic();
            Button button = (Button)sender;
            string text = button.Content.ToString();
            List<string> trueAnswers = logic.FillTrueAnswers("trueAnswers.txt");
            if ((text.Equals(trueAnswers[count - 1]) && count != trueAnswers.Count) || (bool)aegis.IsChecked)
            {
                count++;
                MessageBox.Show("Ты прав");
            }
            else if ((count == trueAnswers.Count) && (text.Equals(trueAnswers[count - 1])))
            {
                MessageBox.Show("Поздравляю, ты выйграл миллион");
                EndGame();
            }
            else
            {
                MessageBox.Show("Ты проиграл");
                EndGame();
            }
            if ((bool)skipNext.IsChecked && count != trueAnswers.Count)
                count++;
            else if (count == trueAnswers.Count)
                MessageBox.Show("Нельзя пропустить последний вопрос");
            FillQuestion(count);
            aegis.IsChecked = false;
            skipNext.IsChecked = false;
            MakeVisible();
        }

        public void FillProgress()
        {
            StreamReader reader = new StreamReader("money.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] arr = line.Split('\t');
                numberToMoney.Add(arr[0], arr[1]);
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
            Logic logic = new Logic();
            Dictionary<string, string[]> questions = logic.FillDictionary("questions.txt");
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

        public void EndGame()
        {
            Logic logic = new Logic();
            logic.FillInScores("scores.txt", player.Text, numberToMoney[count.ToString()]);
            MainWindow mainMenu = new MainWindow();
            mainMenu.Show();
            mainGame.Close();
        }

        private void Aegis_Checked(object sender, RoutedEventArgs e)
        {
            cboxPanel.Children.Remove(aegis);
        }

        private void Half_Checked(object sender, RoutedEventArgs e)
        {
            Logic logic = new Logic();
            List<string> trueAnswers = logic.FillTrueAnswers("trueAnswers.txt");
            string trueAnswer = trueAnswers[count - 1];
            Button[] buttonsToHide = logic.HideButton(new Button[] { b1, b2, b3, b4 }, trueAnswer);
            buttonsToHide[0].Visibility = Visibility.Hidden;
            buttonsToHide[1].Visibility = Visibility.Hidden;
            cboxPanel.Children.Remove(half);
        }

        private void SkipNext_Checked(object sender, RoutedEventArgs e)
        {
            cboxPanel.Children.Remove(skipNext);
        }

        private void MakeVisible()
        {
            b1.Visibility = Visibility.Visible;
            b2.Visibility = Visibility.Visible;
            b3.Visibility = Visibility.Visible;
            b4.Visibility = Visibility.Visible;
        }

        private void EnterPlayerName()
        {
            Logic logic = new Logic();
            string path = "scores.txt";
            Dictionary<string, string> scores = logic.FillTable(path);
            foreach (var pair in scores)
            {
                if (pair.Value.Equals("0"))
                    player.Text = pair.Key;
            }
        }
    }
}
