using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace bialphasprog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private static void Form1_Load(string[] args)
		{
			string filename;

			if (args.Length == 0)
			{
				Console.Write("file path:");
				filename = Console.ReadLine();
			}
			else
			{
				filename = args[0];
			}

			string phrases = LoadPhrases(filename);
			ShowPhrases(phrases);

			RemoveSpecialCharacters(ref phrases);
			ReplaceSpecialCharacters(ref phrases);

			//ShowPhrases(phrases);

			ReplaceNumerics(ref phrases);
			MakeUpercase(ref phrases);
			SplitInToBialphas(ref phrases);
			FirstEncryption(ref phrases);

			ShowPhrases(phrases);

		}

		private static string LoadPhrases(string filename)
		{
			StringBuilder sb = new StringBuilder();
			if (File.Exists(filename))
			{
				foreach (string phrase in File.ReadAllLines(filename))
				{
					sb.Append(phrase);
				}
			}
			return sb.ToString();
		}

		private static void ShowPhrases(string phrases)
		{
			Console.WriteLine(phrases);
		}

		private static void RemoveSpecialCharacters(ref string phrases)
		{
			string[] charactersToRemove = { "@", "_", "-", "(", ")", "+", "=", ",", "\"", "'", ";", "`", "\\" };

			foreach (string character in charactersToRemove)
			{
				phrases = phrases.Replace(character, "");
			}
		}

		private static void ReplaceNumerics(ref string phrases)
		{
			phrases = phrases
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

		private static void ReplaceSpecialCharacters(ref string phrases)
		{
			phrases = phrases
				.Replace(".", "END_SENTENCE_")
				.Replace(" ", "_")
				.Replace("!", "END_EXCLAMATION_")
				.Replace("?", "END_Question_");
		}

		private static void MakeUpercase(ref string phrases)
		{
			phrases = phrases.ToUpper();
		}

		private static void SplitInToBialphas(ref string phrases)
		{
			// make sure the Phrases length is a multiple of 2
			if ((phrases.Length % 2) > 0)
			{
				phrases += "_";
			}

			// store off the length because it is going to change as we add characters
			int length = phrases.Length;
			for (int i = 2; i < length; i += 2)
			{
				phrases = phrases.Insert(i, " ");

				// skip over the character we just added and increase the length by 1
				++i;
				++length;
			}

			// make sure the Phrases length is a multiple of 2
			if ((phrases.Length % 2) > 0)
			{
				phrases += "_";
			}
		}

		private static void FirstEncryption(ref string phrases)
		{
			// Convert Unicode to Bytes

			byte[] uni = Encoding.Unicode.GetBytes(phrases);

			// Convert to ASCII

			string phrasesAscii = Encoding.ASCII.GetString(uni);
			// go through each pair of characters and convert them to digits
			// it should be an even number of characters at this point
			int length = phrasesAscii.Length;
			int test = length;
			for (int i = 0; i < length; i += 5) // + 5 for '0000 ' we want to get to the next place where there is a letter
			{
				if (i < length - 2)
				{
					for (int ii = 0; ii < 2; ++ii)
					{
						int index = i + (ii * 2);

						if (phrasesAscii[index] == '_')
						{
							phrasesAscii = phrasesAscii.Insert(index, "00");
						}
						else
						{
							// - 64 gets 'A' to 1, B to 2, etc.
							// + 26 gets us to the next bigger number after Z

							int character = (int)phrasesAscii[index];
							int transformedCharacter = character - 64 + (ii > 0 ? 26 : 0);

							// each letter was one character, each number we are inserting is from 1 to 2 character, let's 0 pad them all to 2 characters
							// and remove the letter or symbol we just converted

							phrasesAscii = phrasesAscii.Insert(index, transformedCharacter.ToString().PadLeft(2, '0'));
						}

						phrasesAscii = phrasesAscii.Remove(index + 2, 1);
					}

					// we have added a 2 characters and then removed 1 so we need to update length
					length = phrasesAscii.Length;
				}
			}
		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
