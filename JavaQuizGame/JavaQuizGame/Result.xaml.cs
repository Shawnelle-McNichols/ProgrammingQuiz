using System;
using System.Collections.Generic;
using System.Formats.Tar;
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
using static JavaQuizGame.MainWindow;

namespace JavaQuizGame
{
	/// <summary>
	/// Interaction logic for Result.xaml
	/// </summary>
	public partial class Result : Page
	{
		private Player player;
		private List<Question> questions;
		private Dictionary<int, string> playerAnswers;

		public Result(Player player, List<Question> questions, Dictionary<int, string> playerAnswers)
		{
			InitializeComponent();
			this.player = player;
			this.questions = questions;	
			this.playerAnswers = playerAnswers;
			DisplayResults();
		}
		public void DisplayResults() 
		{
			double score = 0;
			double percent;

			for (int i = 0; i < questions.Count; i++) 
			{
				if (questions[i].Answer == playerAnswers[i]) 
				{ 
					score++; 
				}
			}

			percent = (score / 10) * 100;

			player.Score = score;
			player.Percentage = percent;

			name.Text = "Player: " + player.Name;
			category.Text = "Category Played: " + player.PlayedCategory;
			correct.Text = "Score: " + player.Score.ToString() + "/10";
			percentage.Text = "Success Rate: " + player.Percentage.ToString() + "%";

			SuccessMessage(percent);
		}
		public void SuccessMessage(double percent) 
		{
			if (percent <= 50) 
			{
				msg.Text = "Sorry, You need to brush up on your skills.";
			} else if (percent > 50 && percent < 70)
			{
				msg.Text = "Almost There! Just a bit to go!";
			}else
			{
				msg.Text = "You've definitely got this.";
			}
		}
		private void Exit(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
        }
    }
}
