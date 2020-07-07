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
              //|^ Will Be Used later to seprate into bialphas.|
            Console.Write("file path:");
            string phrase0 = Console.ReadLine();
            File.ReadAllLines(phrase0);
            string[] phrase1 = File.ReadAllLines(phrase0);
            Console.WriteLine(phrase1);
            List<string> phrase2 = phrase1.ToList<string>();
            string[] phrase3 = phrase2.TrimToEnd(v1: '@', v2: '_', v3: '-', v4: ')', v5: '(', v6: '+', v7: '='));
                                            //| ^Severity	Code	Description	Project	File	Line	Suppression State Error CS0029  Cannot implicitly convert type 'void' to 'object'   |   
                                            //|biaphasprog C:\Users\Owner\source\repos\bialphasprog\biaphasprog\biaphasprog\Program.cs 23  Active                                           |

            Console.WriteLine(phrase3);
            string[] phrase4 = phrase3.Replace("0", "ZERO ");
                                     //|  ^ Severity	Code	Description	Project	File	Line	Suppression  Error CS1061  'List<string>' does not contain a definition for 'Replace' and no accessible |
                                     //|extension method 'Replace' accepting a first argument of type 'List<string>' could be found(are you missing a using directive or an assembly                        |
                                     //|reference ?)	biaphasprog C:\Users\Owner\source\repos\bialphasprog\biaphasprog\biaphasprog\Program.cs 27  Active                                                  |
            phrase4 = phrase4.Replace("1", "ONE ");
            phrase4 = phrase4.Replace("2", "TWO ");
            phrase4 = phrase4.Replace("3", "THREE ");
            phrase4 = phrase4.Replace("4", "FOUR ");
            phrase4 = phrase4.Replace("5", "FIVE ");
            phrase4 = phrase4.Replace("6", "SIX ");
            phrase4 = phrase4.Replace("7", "SEVEN ");
            phrase4 = phrase4.Replace("8", "EIGHT ");
            phrase4 = phrase4.Replace("9", "NINE ");
            phrase4 = phrase4.Replace(".", "END SENTENCE ");
            
            Console.WriteLine(phrase4);
            goto Start;
        }

        
    }
}
