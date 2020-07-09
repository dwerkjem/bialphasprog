using System;
using System.IO;
using System.Text;

namespace bialphasprog
{
	class Program
	{
		static void Main(string[] args)
		{
			// Will Be Used later to separate into bialphas.
			int pair = 0;

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

			//ShowPhrases(phrases);

			RemoveSpecialCharacters(ref phrases);
			ReplaceSpecialCharacters(ref phrases);

			//ShowPhrases(phrases);

			ReplaceNumerics(ref phrases);

			ShowPhrases(phrases);
		}

		/// <summary>
		/// load the given file into one string
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		private static string LoadPhrases(string filename)
		{
			StringBuilder sb = new StringBuilder();
			if (File.Exists(filename))
			{
				foreach (string phrase in File.ReadAllLines(filename))
				{
					sb.AppendLine(phrase);
				}
			}
			else
			{
				Console.WriteLine(string.Format("File not found: {0}", filename));
			}
			return sb.ToString();
		}

		/// <summary>
		/// display the string to the console
		/// </summary>
		/// <param name="phrases"></param>
		private static void ShowPhrases(string phrases)
		{
			Console.WriteLine(phrases);
		}

		/// <summary>
		/// remove special characters from the string
		/// </summary>
		/// <param name="phrases"></param>
		private static void RemoveSpecialCharacters(ref string phrases)
		{
			string[] charactersToRemove = { "@", "_", "-", "(", ")", "+", "=" };

			foreach (string character in charactersToRemove)
			{
				phrases = phrases.Replace(character, "");
			}
		}

		/// <summary>
		/// replace special characters with words
		/// </summary>
		/// <param name="phrases"></param>
		private static void ReplaceSpecialCharacters(ref string phrases)
		{
			phrases = phrases.Replace(".", " END SENTENCE ");
		}

		/// <summary>
		/// replace numerals with words
		/// </summary>
		/// <param name="phrases"></param>
		private static void ReplaceNumerics(ref string phrases)
		{
			phrases = phrases
				.Replace("0", "ZERO ")
				.Replace("1", "ONE ")
				.Replace("2", "TWO ")
				.Replace("3", "THREE ")
				.Replace("4", "FOUR ")
				.Replace("5", "FIVE ")
				.Replace("6", "SIX ")
				.Replace("7", "SEVEN ")
				.Replace("8", "EIGHT ")
				.Replace("9", "NINE ");
		}
	}
}