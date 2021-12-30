using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// Decker Ayers December 2021
// Helper Class

namespace DailyDeck
{
    class Helper
    {
        public static void ColorRed(string text) // RED
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void ColorGreen(string text) // GREEN
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void ColorBlue(string text) // BLUE
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void ColorMagenta(string text) // PURPLE
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void ColorYellow(string text) // YELLOW
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void ColorYellowWrite(string text) // Changes a Console.Write to Yellow [For Selections]
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void ColorCyan(string text) // CYAN 
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void ColorWhite(string text) // WHITE
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void ColorBlack(string text, string select) // BLACK 
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void DeckerAyers() // Name + Course + DateTime
        {
            ColorGreen("\nDecker Ayers\nNMAD 180.03\n" + DateTime.Now);
        }
        public static void ExitProgram() //GREEN "Goodbye!"
        {
            ColorGreen("\nGoodbye!");
            Environment.Exit(0);
        }
        public static void InputError() // RED "[Input Error -- Please Try Again]"
        {
            Helper.ColorRed("[Input Error -- Please Try Again]");
        }
        public static string DefaultReturnStr() // Return " " 
        {
            return "[Default Return - - Error]";
        }
        public static int DefaultReturnInt() // Returns 0
        {
            return 0;
        }
        public static double DefaultReturnDouble() // 0.0
        {
            return 0.0;
        }
        public static int ValidateNum(int min, int max) // Requires 1. Minimum Choice & 2. Maximum Choice
        {

            while (true)
            {
                Helper.ColorYellowWrite("\nEnter Selection: ");
                if (int.TryParse(Console.ReadLine(), out int output) && output >= min && output <= max)
                {
                    return output;
                }
                else { InputError(); }
            }
        }
        public static string GatherString(string prompt) // Requires prompt string - Returns collected string
        {
            ColorYellowWrite(prompt);
            return Console.ReadLine();
        }
        public static int GatherInt(string prompt) // Requires prompt string - Returns collected string
        {
            ColorYellowWrite(prompt);
            return int.Parse(Console.ReadLine());
        }
        public static double GatherDouble(string prompt) // Requires prompt string - Returns collected string
        {
            ColorYellowWrite(prompt);
            return double.Parse(Console.ReadLine());
        }
        public static bool BoolCollect(string prompt) //Returns bool (used for a key) prompt without (Y/N) required
        {
            while (true)
            {
                string choice = Helper.GatherString("\n" + prompt + "(Y/N): ");
                if (choice == "Y" || choice == "y") { return true; }
                else if (choice == "N" || choice == "n") { return false; }
                else { Helper.InputError(); }
            }
        }

    }

}
