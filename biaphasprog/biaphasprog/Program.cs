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
            char[] MyChar = { '.', '\'', '\"', '?', '\n', ')', '(' };
            string p2 = p1.TrimEnd(MyChar);
            Console.WriteLine(p2);
            if (p2.IndexOf("0") == -1)
            {
                int numbs = 1;
            }
            else if (p2.IndexOf("1") == -1)
            {
                int numbs = 1;
            }
            else if (p2.IndexOf("2") == -1)
            {
                int numbs = 1;
            }
            else if (p2.IndexOf("3") == -1)
            {
                int numbs = 1;
            }
            else if (p2.IndexOf("4") == -1)
            {
                int numbs = 1;
            }
            else if (p2.IndexOf("5") == -1)
            {
                int numbs = 1;
            }
            else if (p2.IndexOf("6") == -1)
            {
                int numbs = 1;
            }
            else if (p2.IndexOf("7") == -1)
            {
                int numbs = 1;
            }
            else if (p2.IndexOf("8") == -1)
            {
                int numbs = 1;
            }
            else if (p2.IndexOf("9") == -1)
            {
                int numbs = 1;
            }
            else
            {
                int numbs = 0;
            }
          
            { 

            }
            goto Start;
        }

    }
}
