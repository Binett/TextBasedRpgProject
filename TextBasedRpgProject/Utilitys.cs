using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextBasedRpgProject.Enemies;

namespace TextBasedRpgProject
{
    static class Utilitys
    {
        static Random rand = new Random();
        public static void PrintGreen(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" " + input);
            Console.ResetColor();
        }
        public static void PrintRed(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" " + input);
            Console.ResetColor();
        }
          

    }
}
