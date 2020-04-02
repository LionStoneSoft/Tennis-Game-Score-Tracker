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

namespace TennisGameScore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Scoreboard> items = new List<Scoreboard>();
        private string[] scoreArray = new string[] { "0", "15", "30", "40", "A" };
        private int playerOneScore = 0;
        private int playerTwoScore = 0;
        private int playerOneTotalScore = 0;
        private int playerTwoTotalScore = 0;
        public MainWindow()
        {
            InitializeComponent();
            playerOneScoredButton.Visibility = Visibility.Hidden;
            playerTwoScoredButton.Visibility = Visibility.Hidden;
            coinFlipButton.Visibility = Visibility.Hidden;
            scoresListView.ItemsSource = items;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void playerOneScoredButton_Click(object sender, RoutedEventArgs e)
        {
            string previousScore = scoreArray[playerOneScore] + "-" + scoreArray[playerTwoScore];
            if (playerOneScore == 3 && playerTwoScore < 3 || playerOneScore == 4 && playerTwoScore == 3)
            {
                playerOneScore = 0;
                playerTwoScore = 0;
                playerOneTotalScore++;
                playerOneScoreLabel.Text = playerOneTotalScore.ToString();
                if (playerOneTotalScore == 6)
                {
                    MessageBox.Show(playerOneLabel.Text + " won the set!");
                }
            } else if (playerOneScore == 3 && playerTwoScore > 3)
            {
                    playerTwoScore--;
            } else
            {
                playerOneScore++;
            }
            items.Insert(0, new Scoreboard() { Score = previousScore, Action = playerOneLabel.Text + " wins a point", Result = scoreArray[playerOneScore] + "-" + scoreArray[playerTwoScore] });
            scoresListView.Items.Refresh();
        }

        private void playerTwoScoredButton_Click(object sender, RoutedEventArgs e)
        {
            string previousScore = scoreArray[playerOneScore] + "-" + scoreArray[playerTwoScore];
            if (playerTwoScore == 3 && playerOneScore < 3 || playerTwoScore == 4 && playerOneScore == 3)
            {
                playerOneScore = 0;
                playerTwoScore = 0;
                playerTwoTotalScore++;
                playerTwoScoreLabel.Text = playerTwoTotalScore.ToString();
                if (playerTwoTotalScore == 6)
                {
                    MessageBox.Show(playerTwoLabel.Text + " won the set!");

                }
            } else if (playerTwoScore == 3 && playerOneScore > 3)
            {
                    playerOneScore--;
            } else
            {
                playerTwoScore++;
            }
                items.Insert(0, new Scoreboard() { Score = previousScore, Action = playerTwoLabel.Text + " wins a point", Result = scoreArray[playerOneScore] + "-" + scoreArray[playerTwoScore] });
                scoresListView.Items.Refresh();
            
        }

        private void coinFlipButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int test = random.Next(0, 2);
            if (test == 0)
            {
                resultOfFlipLabel.Text = playerOneLabel.Text + " serves first!";
            } else
            {
                resultOfFlipLabel.Text = playerTwoLabel.Text + " serves first!";
            }
        }
        

        private void nameSubmitButton_Click(object sender, RoutedEventArgs e)
        {
                playerOneLabel.Text = playerOneTextBox.Text;
                playerTwoLabel.Text = playerTwoTextBox.Text;
                playerOneTextBox.Visibility = Visibility.Hidden;
                playerTwoTextBox.Visibility = Visibility.Hidden;
                playerOneScoredButton.Visibility = Visibility.Visible;
                playerTwoScoredButton.Visibility = Visibility.Visible;
                nameSubmitButton.Visibility = Visibility.Hidden;
                coinFlipButton.Visibility = Visibility.Visible;

        }
    }

    public class Scoreboard
    {
        public string Score { get; set; }

        public string Action { get; set; }

        public string Result { get; set; }
    }

}
