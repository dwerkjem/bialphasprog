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
		/// <summary>
		/// true when we are running the encryption process
		/// </summary>
		private bool _encrypting = false;

		/// <summary>
		/// main form constructor
		/// </summary>
		public Form1()
		{
			InitializeComponent();
		}

		/// <summary>
		/// handle the form load event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			phraseTextBox.Text = File.ReadAllText(@"Resources\phrases.txt");
		}

		/// <summary>
		/// handle the go button (encrypt) click event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GoButton_Click(object sender, EventArgs e)
		{
			_encrypting = true;
			GoButton.Enabled = false;

			// just remember that the order of things happening is from the inside out
			string text =
				ConvertCharactersToDigits(
				AddSpacesBetweenBialphas(
				RemoveOrReplaceCharacters(phraseTextBox.Text).ToUpper()
				));

			UpdateDisplay(text);
			PlaySound();
			_encrypting = false;
		}

		/// <summary>
		/// plan a sound
		/// </summary>
		private static void PlaySound()
		{
			using (SoundPlayer sound = new SoundPlayer(@"Resources\Windows Background.wav"))
			{
				sound.Play();
			}
		}

		/// <summary>
		/// update the text box and give to th UI thread a chance to display it
		/// </summary>
		/// <param name="text"></param>
		private void UpdateDisplay(string text)
		{
			phraseTextBox.Text = text;
			Application.DoEvents();
		}

		/// <summary>
		/// return a new string with each alpha character replaced with a 2 digit number representing its place in the alphabet (A=1, B=2, C=3...)
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		private string ConvertCharactersToDigits(string text)
		{
			StringBuilder newText = new StringBuilder(text.Length * 2);

			foreach (char character in text)
			{
				switch (character)
				{
					case ' ':
						newText.Append(" ");
						break;

					case '_':
						newText.Append("00");
						break;

					// everything left should be an alphabetic character
					default:
						{
							// - 64 gets 'A' to 1, B to 2, etc.						
							int transformedCharacter = character - 64;

							newText.Append(transformedCharacter.ToString().PadLeft(2, '0'));
						}
						break;
				}
			}

			return newText.ToString();
		}

		/// <summary>
		/// add a space character after each bialpha
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
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
				newText.Append(" ");
			}

			return newText.ToString();
		}

		/// <summary>
		/// create a new string with all characters to remove removed and all characters to replace replaced
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		private static string RemoveOrReplaceCharacters(string text)
		{
			StringBuilder newText = new StringBuilder(text.Length * 2);

			foreach (char character in text)
			{
				// just looking for ascii alphanumeric characters plus a few more
				switch (character)
				{
					// special characters to replace
					case '.':
						newText.Append("END_SENTENCE_");
						break;

					case ' ':
						newText.Append('_');
						break;

					case '!':
						newText.Append("END_EXCLAMATION_");
						break;

					case '?':
						newText.Append("END_QUESTION_");
						break;

					// numerals to replace
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
						// at this point we only want A-Z and a-z
						int asciiValue = (int)character;
						if ((asciiValue >= 65 && asciiValue <= 90) || (asciiValue >= 97 && asciiValue <= 122))
						{
							newText.Append(character);
						}
						break;
				}
			}

			return newText.ToString();
		}

		/// <summary>
		/// make sure the go (encrypt) button is enabled if any text is changed in the text box (unless it is the program changing the text)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PhraseTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!_encrypting)
			{
				GoButton.Enabled = true;
			}
		}
	}
}




