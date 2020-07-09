using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

			//ShowPhrases(phrases);

			RemoveSpecialCharacters(ref phrases);
			ReplaceSpecialCharacters(ref phrases);

			//ShowPhrases(phrases);

			ReplaceNumerics(ref phrases);
			MakeUpercase(ref phrases);

			SplitInToBialphas(ref phrases);

			ShowPhrases(phrases);
		}

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
			return sb.ToString();
		}

		private static void ShowPhrases(string phrases)
		{
			Console.WriteLine(phrases);
		}

		private static void RemoveSpecialCharacters(ref string phrases)
		{
			string[] charactersToRemove = { "@", "_", "-", "(", ")", "+", "=" };

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
				.Replace(" ", "_");
		}

		private static void MakeUpercase(ref string phrases)
		{
			phrases = phrases.ToUpper();
		}

		private static void SplitInToBialphas(ref string phrases)
		{
			int pair;
			if ((phrases.Length % 2) > 0)
			{
				//is decimal
				pair = phrases.Length;
				phrases += "_";
				phrases = phrases.Insert(pair - 2, " ");
			}
			else
			{
				//is int
				pair = phrases.Length;
				phrases = phrases.Insert(pair - 2, " ");
			}
		}

		private static void Pause()
		{
			Console.ReadLine();
		}
	}
}
