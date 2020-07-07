using System;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace bialphasprog
{
    class Program
    {
        static void Main(string[] args)

        {
            Start:
            int pair = 0;
            Console.Write("file path:");
            string phrase0 = Console.ReadLine(); 
            File.ReadAllLines(phrase0);
            string[] phrase1 = File.ReadAllLines(phrase0);
            Console.WriteLine(phrase1);
            List<string> phrase2 = phrase1.ToList<string>();
            phrase2.TrimToEnd('@', '_', '-', ')', '(', '+', '=');
            //          ^ Severity	Code	Description	Project	File	Line	Suppression  Error CS1061  'List<string>' does not contain a definition for 'TrimToEnd' and no accessible extension method 'TrimToEnd' accepting a first argument of type 'List<string>' could be found(are you missing a using directive or an assembly reference ?)	biaphasprog C:\Users\Owner\source\repos\bialphasprog\biaphasprog\biaphasprog\Program.cs 23  Active

            Console.WriteLine(phrase2);
            string[] phrase3 = phrase2.Replace("0", "ZERO ");
                                     //  ^ Severity	Code	Description	Project	File	Line	Suppression  Error CS1061  'List<string>' does not contain a definition for 'Replace' and no accessible extension method 'Replace' accepting a first argument of type 'List<string>' could be found(are you missing a using directive or an assembly reference ?)	biaphasprog C:\Users\Owner\source\repos\bialphasprog\biaphasprog\biaphasprog\Program.cs 27  Active

            phrase3 = phrase3.Replace("1", "ONE ");
            phrase3 = phrase3.Replace("2", "TWO ");
            phrase3 = phrase3.Replace("3", "THREE ");
            phrase3 = phrase3.Replace("4", "FOUR ");
            phrase3 = phrase3.Replace("5", "FIVE ");
            phrase3 = phrase3.Replace("6", "SIX ");
            phrase3 = phrase3.Replace("7", "SEVEN ");
            phrase3 = phrase3.Replace("8", "EIGHT ");
            phrase3 = phrase3.Replace("9", "NINE ");
            phrase3 = phrase3.Replace(".", "END SENTENCE ");
            
            Console.WriteLine(phrase3);
            goto Start;
        }

    }
}
