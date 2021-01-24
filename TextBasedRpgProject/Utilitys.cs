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

        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|------------------------------------------------------------> Print in green <-----------------------------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        public static void PrintGreen(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("" + input);
            Console.ResetColor();
        }

        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|------------------------------------------------------------> Print in Red <-------------------------------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        public static void PrintRed(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("" + input);
            Console.ResetColor();
        }


        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|------------------------------------------------------------> Print in Yellow <-------------------------------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/


        public static void PrintYellow(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("" + input);
            Console.ResetColor();
        }


        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|-------------------------------------------------------> Displays xp bar in menu <-------------------------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        public static void ProgressBar(Player player, decimal value, int size)
        {
            Console.WriteLine($"Experience bar\t\t\tXP:{player.Xp}/{player.XpToLevel()}");
            int diferential = (int)(value * size);
            for (int i = 0; i < size; i++)
            {

                if (i < diferential)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write(" ");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" ");
                    Console.ResetColor();
                }
            }
            Console.WriteLine("");
            PrintGreen($"Level: {player.level}");           
        }

        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|-------------------------------------------------> Displays the enemys health int battle <-----------------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        public static void HealtBar(Enemy enemy, decimal value, int size)
        {
            int diferential = (int)(value * size);
            for (int i = 0; i < size; i++)
            {

                if (i < diferential)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write(" ");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" ");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }

        /*|-----------------------------------------------------------------------------------------------------------------------------------------------------|
         *|-------------------------------------------------> Displays the players health int battle <----------------------------------------------------------|
         *|-----------------------------------------------------------------------------------------------------------------------------------------------------|*/

        public static void HealtBar(Player player, decimal value, int size)
        {
            int diferential = (int)(value * size);
            for (int i = 0; i < size; i++)
            {

                if (i < diferential)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write(" ");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" ");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }


    }
}
