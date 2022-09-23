using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payloads.util
{
    public class ProgressBar
    {
        public static void ProgressBarConsole(int progress, int total)
        {
            Console.CursorLeft = 0;
            Console.Write("[");
            Console.CursorLeft = 32;
            Console.Write("]");
            Console.CursorLeft = 0;
            Console.CursorLeft = 35;
            Console.Write("Downloading files...");
            Console.CursorLeft = 1;
            for (int i = 0; i < total * progress; i++)
            {
                Console.Write("#");
                Console.CursorLeft++;
            }
        }
    }
}
