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
using static JavaQuizGame.MainWindow;

namespace JavaQuizGame
{
	/// <summary>
	/// Interaction logic for QuestionPage.xaml
	/// </summary>
	public partial class QuestionPage : Page
	{
		private Player player;
		private List<Question> questions;
		private int currentIndex;
		private Dictionary<int, string> playerAnswers;
		public QuestionPage(Player player, List<Question> questions)
		{
			InitializeComponent();
			this.player = player;
			this.questions = questions;
			currentIndex = 0;
			playerAnswers = new Dictionary<int, string>();
			DisplayQuestion();

		}
		private void UpdateNavigationButton     ()
		{
			if (currentIndex >= questions.Count - 1)
			{
				btnNext.Content = "Submit";
			}
			else
			{
				btnNext.Content = "Next";
			}
		}
		private void DisplayQuestion()
		{
			if (currentIndex >= 0 && currentIndex < questions.Count)
			{
				opt1.IsChecked = false;
				opt2.IsChecked = false;
				opt3.IsChecked = false;
				opt4.IsChecked = false;

				Question.Text = questions[currentIndex].Text;
				txt1.Text = questions[currentIndex].Options[0];
				opt1.Content = txt1;
				txt2.Text = questions[currentIndex].Options[1];
				opt2.Content = txt2;
				txt3.Text = questions[currentIndex].Options[2];
				opt3.Content = txt3;
				txt4.Text = questions[currentIndex].Options[3];
				opt4.Content = txt4;

				UpdateNavigationButton();
			}
		}
		private bool SaveAnswer()
		{
			if (opt1.IsChecked == true)
				{ 
				playerAnswers[currentIndex] = ((TextBlock)opt1.Content).Text; 
				return true;
			}
			else if (opt2.IsChecked == true)
				{
				playerAnswers[currentIndex] = ((TextBlock)opt2.Content).Text;
				return true;
			}
			else if (opt3.IsChecked == true)
				{ 
				playerAnswers[currentIndex] = ((TextBlock)opt3.Content).Text;
				return true;
			}
			else if (opt4.IsChecked == true)
			{ 
				playerAnswers[currentIndex] = ((TextBlock)opt4.Content).Text;
				return true;
			}
			else { MessageBox.Show("Please select an answer.");
				return false;
			}
		}
		private void Next(object sender, RoutedEventArgs e)
		{
			bool isSelected = SaveAnswer();

			/*if (currentIndex < questions.Count - 1) 
			{ 
				currentIndex++;
				DisplayQuestion();
			}
			else
			{
				SaveAnswer();//
			}*/
			if (isSelected)
			{
				if (btnNext.Content.ToString() == "Submit")
				{
					SubmitAnswers();
				}
				else
				{
					currentIndex++;
					DisplayQuestion();
				}
			}
		}

		private void Previous(object sender, RoutedEventArgs e)
		{
			currentIndex--;
			DisplayQuestion();

		}

		private void SubmitAnswers()
		{
			this.NavigationService.Navigate(new Result(player, questions, playerAnswers));
		}

		private void opt1_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void opt4_Checked(object sender, RoutedEventArgs e)
		{

		}

		private void Back(object sender, RoutedEventArgs e)
		{
			this.NavigationService.Navigate(new QuestionChoice(player));
		}
	}
}
