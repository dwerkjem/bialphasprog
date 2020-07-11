using System;
using System.IO;
using System.Linq;
using System.Media;
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

			text = ReplaceNumerals(text);

			text = ReplaceSpecialCharacters(text);

			text = text.ToUpper();

			AddSpacesBetweenBialphas(ref text);

			ConvertCharactersToDigits(ref text);

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

		private void ConvertCharactersToDigits(ref string text)
		{
			int length;
			// go through each pair of characters and convert them to digits
			// it should be an even number of characters at this point

			int spaces = text.Count(s => s == ' ');

			length = text.Length;

			int newLength = (length - spaces) * 2 + spaces;

			EncryptionProgressBar.Maximum = newLength;
			EncryptionProgressBar.Minimum = 0;
			EncryptionProgressBar.Step = 5;

			for (int i = 0; i < length; i += 5) // + 5 for '0000 ' we want to get to the next place where there is a letter
			{
				EncryptionProgressBar.PerformStep();
				Application.DoEvents();

				for (int ii = 0; ii < 2; ++ii)
				{
					int index = i + (ii * 2);

					if (text[index] == '_')
					{
						text = text.Insert(index, "00");
					}
					else
					{
						// - 64 gets 'A' to 1, B to 2, etc.
						

						int character = (int)text[index];
						int transformedCharacter = character - 64 + (ii > 0 ? 0 : 0);

						// each letter was one character, each number we are inserting is from 1 to 2 character, let's 0 pad them all to 2 characters

						text = text.Insert(index, transformedCharacter.ToString().PadLeft(2, '0'));
					}

					// and remove the letter or symbol we just converted
					text = text.Remove(index + 2, 1);
				}

				// we have added a 2 characters and then removed 1 so we need to update length
				length = text.Length;

				phraseTextBox.Text = text;
			}
		}

		private static void AddSpacesBetweenBialphas(ref string text)
		{
			// make sure the text length is a multiple of 2
			if ((text.Length % 2) > 0)
			{
				text += "_";
			}

			// store off the length because it is going to change as we add characters
			int length = text.Length;
			for (int i = 2; i < length; i += 2)
			{
				text = text.Insert(i, " ");

				// skip over the character we just added and increase the length by 1
				++i;
				++length;
			}

			//// make sure the text length is a multiple of 2
			//if ((text.Length % 2) > 0)
			//{
			//	text += "_";
			//}

			// we need it to end with a space for processing later
			text += " ";
		}

		private static string ReplaceSpecialCharacters(string text)
		{
			text = text
				.Replace(".", "END_SENTENCE_")
				.Replace(" ", "_")
				.Replace("!", "END_EXCLAMATION_")
				.Replace("?", "END_QUESTION_")
				.Replace("\t", "_");
			return text;
		}

		private static string ReplaceNumerals(string text)
		{
			text = text
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
			return text;
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




