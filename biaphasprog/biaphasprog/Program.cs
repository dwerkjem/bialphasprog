using System;
using System.Globalization;
using System.Threading;

namespace bialphasprog
{
    class Program
    {
        static void Main(string[] args)

        {
            Start:
            int pair = 0;
            Console.Write("phrase:");
            string p0 = Console.ReadLine(); 
            string p1 = (p0.ToUpper());
            Console.WriteLine(p1);
            char[] MyChar = { '@', '_', '-', ')', '(', '+', '=' };
            string p2 = p1.TrimEnd(MyChar);
            Console.WriteLine(p2);
            string p3 = p2.Replace("0", "ZERO ");
            p3 = p3.Replace("1", "ONE ");
            p3 = p3.Replace("2", "TWO ");
            p3 = p3.Replace("3", "THREE ");
            p3 = p3.Replace("4", "FOUR ");
            p3 = p3.Replace("5", "FIVE ");
            p3 = p3.Replace("6", "SIX ");
            p3 = p3.Replace("7", "SEVEN ");
            p3 = p3.Replace("8", "EIGHT ");
            p3 = p3.Replace("9", "NINE ");
            Console.WriteLine(p3);
            goto Start;
        }

    }
}
