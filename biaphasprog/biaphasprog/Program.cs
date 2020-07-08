using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

			string[] phraseArray = File.ReadAllLines(filename);

			//ShowPhrases(phraseArray);

			List<string> phrases = phraseArray.ToList<string>();

			RemoveSpecialCharacters(ref phrases);
			ReplaceSpecialCharacters(ref phrases);

			//ShowPhrases(phrases);

			ReplaceNumerics(ref phrases);

			ShowPhrases(phrases);
		}

		private static void ShowPhrases(string[] phrases)
		{
			foreach (string phrase in phrases)
			{
				Console.WriteLine(phrase);
			}
		}

		private static void ShowPhrases(List<string> phrases)
		{
			foreach (string phrase in phrases)
			{
				Console.WriteLine(phrase);
			}
		}

		private static void RemoveSpecialCharacters(ref List<string> phrases)
		{
			string[] charactersToRemove = { "@", "_", "-", "(", ")", "+", "=" };

			for (int i = 0; i < phrases.Count; ++i)
			{
				foreach (string character in charactersToRemove)
				{
					phrases[i] = phrases[i].Replace(character, "");
				}
			}
		}

		private static void ReplaceSpecialCharacters(ref List<string> phrases)
		{
			for (int i = 0; i < phrases.Count; ++i)
			{
				phrases[i] = phrases[i].Replace(".", " END SENTENCE ");
			}
		}

		private static void ReplaceNumerics(ref List<string> phrases)
		{
			for (int i = 0; i < phrases.Count; ++i)
			{
				phrases[i] = phrases[i]
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
}