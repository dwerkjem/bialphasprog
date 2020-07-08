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

			//ShowPhrases(phrase1);

			List<string> phrases = phraseArray.ToList<string>();

			RemoveSpecialCharacters(ref phrases);
			ReplaceSpecialCharacters(ref phrases);

			//ShowPhrases(phrases);

			ReplaceNumerics(ref phrases);
			MakeUpercase(ref phrases);
			
			SplitInToBialphas(ref phrases);


			ShowPhrases(phrases);
			Pause(ref phrases);
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

		private static void ReplaceNumerics(ref List<string> phrases)
		{
			for (int i = 0; i < phrases.Count; ++i)
			{
				phrases[i] = phrases[i].Replace("0", "ZERO_");
				phrases[i] = phrases[i].Replace("1", "ONE_");
				phrases[i] = phrases[i].Replace("2", "TWO_");
				phrases[i] = phrases[i].Replace("3", "THREE_");
				phrases[i] = phrases[i].Replace("4", "FOUR_");
				phrases[i] = phrases[i].Replace("5", "FIVE_");
				phrases[i] = phrases[i].Replace("6", "SIX_");
				phrases[i] = phrases[i].Replace("7", "SEVEN_");
				phrases[i] = phrases[i].Replace("8", "EIGHT_");
				phrases[i] = phrases[i].Replace("9", "NINE_");
			}

		}
		private static void ReplaceSpecialCharacters(ref List<string> phrases)
		{
			for (int i = 0; i < phrases.Count; ++i)
			{
				phrases[i] = phrases[i].Replace(".", "END_SENTENCE_");
				phrases[i] = phrases[i].Replace(" ", "_");
			}

		}
		private static void MakeUpercase(ref List<string> phrases)
		{
            for (int i = 0; i < phrases.Count; ++i)
			{
				phrases[i] = phrases[i].ToUpper();
			}
		}
		
		private static void SplitInToBialphas(ref List<string> phrases)
        {
			
			int pair;
			for (int i = 0; i < phrases.Count; ++i)
            {
				
				if ((phrases[i].Length % 2) > 0)
				{
					//is decimal
					pair = phrases[i].Length;
					phrases[i] = phrases+"_";
					phrases[i] = phrases[i].Insert(pair - 2, " ");
				}
				else
				{
                    //is int
                    pair = phrases[i].Length;
					phrases[i] = phrases[i].Insert(pair - 2, " ");
                }
                
			}
            
		}
		private static void Pause(ref List<string> phrases)
		{
			Console.ReadLine();
		}
	}
}
