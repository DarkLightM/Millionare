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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Millionare
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            mainMenu.Close();
        }

        private void ScoreButton_Click(object sender, RoutedEventArgs e)
        {
            Score scoreWindow = new Score();
            scoreWindow.Show();
            mainMenu.Close();
        }

        private void GameButton_Click(object sender, RoutedEventArgs e)
        {
            Logic logic = new Logic();
            logic.FillInScores("scores.txt", nameBox.Text, "0");
            MainGame main = new MainGame();
            main.Show();
            mainMenu.Close();
        }
    }
}
