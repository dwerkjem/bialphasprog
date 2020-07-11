using System;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace biaphasprogform
{
	public partial class Form1 : Form
	{
		private bool _encrypting = false;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			string phrases = File.ReadAllText(@"Resources\phrases.txt");
			phraseTextBox.Text = phrases;
		}

		private void GoButton_Click(object sender, EventArgs e)
		{
			GoButton.Enabled = false;
			_encrypting = true;

			PlaySound();

			string text = phraseTextBox.Text;

			text = RemoveSpecialCharacters(text);
			UpdateDisplay(text);

			text = ReplaceNumerals(text);
			UpdateDisplay(text);

			text = ReplaceSpecialCharacters(text);
			UpdateDisplay(text);

			text = text.ToUpper();
			UpdateDisplay(text);

			text = AddSpacesBetweenBialphas(text);

			text = ConvertCharactersToDigits(text);

			MessageBox.Show("Finished", "Encryption", MessageBoxButtons.OK, MessageBoxIcon.Information);
			_encrypting = false;
		}

		private static void PlaySound()
		{
			using (SoundPlayer sound = new SoundPlayer(@"Resources\Windows Background.wav"))
			{
				sound.Play();
			}
		}

		private void UpdateDisplay(string text)
		{
			phraseTextBox.Text = text;
			Application.DoEvents();
		}

		private string ConvertCharactersToDigits(string text)
		{
			//EncryptionProgressBar.Maximum = text.Length;
			//EncryptionProgressBar.Minimum = 0;
			//EncryptionProgressBar.Step = 1;

			StringBuilder newText = new StringBuilder(text.Length * 2);

			foreach (char character in text)
			{
				if (character == ' ')
				{
					newText.Append(" ");
				}
				else if (character == '_')
				{
					newText.Append("00");
				}
				else
				{
					// - 64 gets 'A' to 1, B to 2, etc.						
					int transformedCharacter = character - 64;

					newText.Append(transformedCharacter.ToString().PadLeft(2, '0'));
				}

				//EncryptionProgressBar.PerformStep();
			}

			UpdateDisplay(newText.ToString());

			return newText.ToString();
		}

		private string AddSpacesBetweenBialphas(string text)
		{
			StringBuilder newText = new StringBuilder(text.Length / 3 * 2);

			int count = 0;
			foreach (char character in text)
			{
				newText.Append(character);
				if ((++count % 2) == 0)
				{
					newText.Append(" ");
				}
			}

			// make sure the text length is a multiple of 2
			if ((newText.Length % 2) > 0)
			{
				newText.Append("_");
			}

			return newText.ToString();
		}

		private static string ReplaceSpecialCharacters(string text)
		{
			return text
				.Replace(".", "END_SENTENCE_")
				.Replace(" ", "_")
				.Replace("!", "END_EXCLAMATION_")
				.Replace("?", "END_QUESTION_")
				.Replace("\t", "_");
		}

		private static string ReplaceNumerals(string text)
		{
			return text
				.Replace("0", "ZERO_")
				.Replace("1", "ONE_")
				.Replace("2", "TWO_")
				.Replace("3", "THREE_")
				.Replace("4", "FOUR_")
				.Replace("5", "FIVE_")
				.Replace("6", "SIX_")
				.Replace("7", "SEVEN_")
				.Replace("8", "EIGHT_")
				.Replace("9", "NINE_");
		}

		private static string RemoveSpecialCharacters(string text)
		{
			string[] charactersToRemove = { "@", "_", "-", "(", ")", "+", "=", ",", "\"", "'", ";", "`", "\\", "\r", "\n" };

			foreach (string character in charactersToRemove)
			{
				text = text.Replace(character, "");
			}

			return text;
		}

		private void phraseTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!_encrypting)
			{
				GoButton.Enabled = true;
			}
		}
	}
}




