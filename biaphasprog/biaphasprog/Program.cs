using System;
using System.IO;
using System.Text;

namespace bialphasprog
{
	class Program
	{
		static void Main(string[] args)
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

			Pause();
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
			string[] charactersToRemove = { "@", "_", "-", "(", ")", "+", "=", ",", "\"", "'", ";", "`"};

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

		private static void Pause()
		{
			Console.WriteLine("Hit any key to continue...");
			Console.ReadKey();
		}

		private static void FirstEncryption(ref string phrases)
        {
			// go through each pair of characters and convert them to digits
			// it should be an even number of characters at this point
			int length = phrases.Length;
			int test = length;
			for (int i = 0; i < length; i += 5) // + 5 for '0000 ' we want to get to the next place where there is a letter
			{
				if (i < length - 2)
				{
					for (int ii = 0; ii < 2; ++ii)
					{
						int index = i + (ii * 2);

						if (phrases[index] == '_')
						{
							phrases = phrases.Insert(index, "00");
						}
						else
						{
							// - 64 gets 'A' to 1, B to 2, etc.
							// + 26 gets us to the next bigger number after Z

							int character = (int)phrases[index];
							int transformedCharacter = character - 64 + (ii > 0 ? 26 : 0);

							// each letter was one character, each number we are inserting is from 1 to 2 character, let's 0 pad them all to 2 characters
							// and remove the letter or symbol we just converted

							phrases = phrases.Insert(index, transformedCharacter.ToString().PadLeft(2, '0'));
						}

						phrases = phrases.Remove(index + 2, 1);
					}

					// we have added a 2 characters and then removed 1 so we need to update length
					length = phrases.Length;
				}

			}
			//phrases = phrases
			//	.Replace("_", " 0 ")
			//	.Replace("A", " 1 ")
			//	.Replace("B", " 2 ")
			//	.Replace("C", " 3 ")
			//	.Replace("D", " 4 ")
			//	.Replace("E", " 5 ")
			//	.Replace("F", " 6 ")
			//	.Replace("G", " 7 ")
			//	.Replace("H", " 8 ")
			//	.Replace("I", " 9 ")
			//	.Replace("J", " 10 ")
			//	.Replace("K", " 11 ")
			//	.Replace("L", " 12 ")
			//	.Replace("N", " 14 ")
			//	.Replace("M", " 13 ")
			//	.Replace("O", " 15 ")
			//	.Replace("P", " 16 ")
			//	.Replace("Q", " 17 ")
			//	.Replace("R", " 18 ")
			//	.Replace("S", " 19 ")
			//	.Replace("T", " 20 ")
			//	.Replace("U", "21 ")
			//	.Replace("V", "22 ")
			//	.Replace("W", " 23 ")
			//	.Replace("X", " 24 ")
			//	.Replace("Y", " 25 ")
			//	.Replace("Z", " 26 ");
			

		}
	}
}
