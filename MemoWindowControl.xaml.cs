using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SimpleNotepad
{
	/// <summary>
	/// Interaction logic for MemoWindowControl.
	/// </summary>
	public partial class MemoWindowControl : UserControl
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MemoWindowControl"/> class.
		/// </summary>
		public MemoWindowControl()
		{
			this.InitializeComponent();


		}

		public void LoadText()
		{
			string solutionDirectory = Path.GetDirectoryName(this.GetType().Assembly.Location);
			string filePath = Path.Combine(solutionDirectory, "memo.txt");

			if (File.Exists(filePath))
			{
				try
				{
					// memo.txt 파일 읽기
					string memoText = File.ReadAllText(filePath);

					// TextBlock에 읽은 내용 설정
					MemoTextBox.Text = memoText;
				}
				catch (IOException ex)
				{
					MessageBox.Show($"Error reading memo.txt: {ex.Message}");
				}
			}
			else
			{
				File.WriteAllText(filePath, "");
			}
		}

		public void SaveText()
		{
			string solutionDirectory = Path.GetDirectoryName(this.GetType().Assembly.Location);
			string filePath = Path.Combine(solutionDirectory, "memo.txt");
			File.WriteAllText(filePath, MemoTextBox.Text);
		}

		/// <summary>
		/// Handles click on the button by displaying a message box.
		/// </summary>
		/// <param name="sender">The event sender.</param>
		/// <param name="e">The event args.</param>
		[SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
		private void SaveButton_Callback(object sender, RoutedEventArgs e)
		{
			SaveText();
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

        }
    }
}