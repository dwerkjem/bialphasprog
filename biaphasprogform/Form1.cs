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
			StringBuilder newText = new StringBuilder(text.Length * 2);
			foreach (char character in text)
			{
				switch (character)
				{
					case '.':
						newText.Append("END_SENTENCE_");
						break;

					case '\t':
					case ' ':
						newText.Append('_');
						break;

					case '!':
						newText.Append("END_EXCLAMATION_");
						break;

					case '?':
						newText.Append("END_QUESTION_");
						break;

					default:
						newText.Append(character);
						break;
				}
			}
			return newText.ToString();
		}

		private static string ReplaceNumerals(string text)
		{
			StringBuilder newText = new StringBuilder(text.Length * 2);
			foreach (char character in text)
			{
				switch (character)
				{
					case '0':
						newText.Append("ZERO_");
						break;

					case '1':
						newText.Append("ONE_");
						break;

					case '2':
						newText.Append("TWO_");
						break;

					case '3':
						newText.Append("THREE_");
						break;

					case '4':
						newText.Append("FOUR_");
						break;

					case '5':
						newText.Append("FIVE_");
						break;

					case '6':
						newText.Append("SIX_");
						break;

					case '7':
						newText.Append("SEVEN_");
						break;

					case '8':
						newText.Append("EIGHT_");
						break;

					case '9':
						newText.Append("NINE_");
						break;

					default:
						newText.Append(character);
						break;
				}
			}
			return newText.ToString();
		}

		private static string RemoveSpecialCharacters(string text)
		{
			char[] charactersToRemove = { '@', '_', '-', '(', ')', '+', '=', ',', '"', '\'', ';', '`', '\\', '\r', '\n' };
			StringBuilder newText = new StringBuilder(text.Length);

			foreach (char character in text)
			{
				if (!charactersToRemove.Contains(character))
				{
					newText.Append(character);
				}
			}

			return newText.ToString();
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




