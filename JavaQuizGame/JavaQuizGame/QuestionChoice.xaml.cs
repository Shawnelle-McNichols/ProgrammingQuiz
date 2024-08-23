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
using System.IO;
using Newtonsoft.Json;
using static JavaQuizGame.MainWindow;

namespace JavaQuizGame
{
	/// <summary>
	/// Interaction logic for QuestionChoice.xaml
	/// </summary>
	public partial class QuestionChoice : Page
	{
		private Player player;
		private string selectedCategory;
		public QuestionChoice(Player player)
		{
			InitializeComponent();
			this.player = player;
			
		}

		private Quiz LoadQuiz()
		{
			string filePath = "C:\\Users\\user\\source\\repos\\JavaQuizGame\\JavaQuizGame\\Data\\Questions.json";
			string jsonData = File.ReadAllText(filePath);
			return JsonConvert.DeserializeObject<Quiz>(jsonData);
		}
		private List<Question> LoadQuestionsByCategories(string selectedCategory) 
		{ 
			player.PlayedCategory = selectedCategory;
			Quiz quiz = LoadQuiz();
			if (quiz.Categories.ContainsKey(selectedCategory)) 
			{ 
				return quiz.Categories[selectedCategory];
			}
			else
			{
				MessageBox.Show("No questions found for this category");
				return new List<Question>();
			}
		}
		private void LoadQuizPage(List<Question> selectedQuestions) 
		{
			if (selectedQuestions.Count > 0) 
			{
				this.NavigationService.Navigate(new QuestionPage(player, selectedQuestions));
			}
		}
		private void Programming(object sender, RoutedEventArgs e)
		{
			selectedCategory = "Programming";
			List<Question> selectedQuestions = LoadQuestionsByCategories(selectedCategory);
			LoadQuizPage(selectedQuestions);
		}

		private void Webdev(object sender, RoutedEventArgs e)
		{
			selectedCategory = "Web Development";
			List<Question> selectedQuestions = LoadQuestionsByCategories(selectedCategory);
			LoadQuizPage(selectedQuestions);
		}

		private void Java(object sender, RoutedEventArgs e)
		{
			selectedCategory = "Java";
			List<Question> selectedQuestions = LoadQuestionsByCategories(selectedCategory);
			LoadQuizPage(selectedQuestions);
		}

		private void Cplus(object sender, RoutedEventArgs e)
		{
			selectedCategory = "C++";
			List<Question> selectedQuestions = LoadQuestionsByCategories(selectedCategory);
			LoadQuizPage(selectedQuestions);
		}

		private void DSA(object sender, RoutedEventArgs e)
		{
			selectedCategory = "DSA";
			List<Question> selectedQuestions = LoadQuestionsByCategories(selectedCategory);
			LoadQuizPage(selectedQuestions);
		}

		private void OOP(object sender, RoutedEventArgs e)
		{
			selectedCategory = "OOP";
			List<Question> selectedQuestions = LoadQuestionsByCategories(selectedCategory);
			LoadQuizPage(selectedQuestions);
		}

		private void Back(object sender, RoutedEventArgs e)
		{
			MainWindow main = new MainWindow();
			main.Show();
			Window.GetWindow(this).Close();
		}
	}
}
