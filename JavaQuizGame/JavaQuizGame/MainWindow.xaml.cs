using System.Text;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace JavaQuizGame
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public class Player
		{
			public string Name { get; set; }
			public string PlayedCategory { get; set; }
			public double Score { get; set; }
			public double Percentage { get; set; }
		}

		public class Question
		{
			public string Text { get; set; }
			public List<string> Options { get; set; }
			public string Answer { get; set; }
		}

		public class Quiz
		{
			public Dictionary<string, List<Question>> Categories { get; set; }
		}

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Play_Click(object sender, RoutedEventArgs e)
		{
			string playerName = name.Text;
			if (!string.IsNullOrEmpty(playerName)) 
			{ 
				Player player = new Player 
				{
					Name = playerName
				}; 
				MainFrame.Navigate(new QuestionChoice(player));
			}
			else
			{
				MessageBox.Show("Please enter your name to continue.");
			}
		}

	
	}
}