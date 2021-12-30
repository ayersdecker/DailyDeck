using System;
using System.IO;
using System.Collections.Generic;

namespace DailyDeck
{
    class Program
    {
        static Dictionary<string, Assignment> asnDictionary = new Dictionary<string, Assignment>();
        static void Main(string[] args)
        {
            IntroMessage(); // INTRO DISPLAY BANNER + TIME 
            while (true)    // FOREVER LOOP
            {
                int selection = MenuDisplay(); // MENU DISPLAY
                switch (selection)
                {
                    case 1: // VIEW PLANNER
                        ViewPlanner();
                        break;
                    case 2: // ENTER AN ASSIGNMENT
                        EnterAsn();
                        break;
                    case 3: // REMOVE ASSIGNMENT
                        RemoveAsn();
                        break;
                    case 4: // EXIT PROGRAM
                        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n\tGoodbye!\n\n\n");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("[FATAL ERROR HAS OCCURED -- EXITING PROGRAM]");
                        Environment.Exit(0);
                        break;
                }
            }
        }
        private static void IntroMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n\n\n\n\n\n\t   ////    //   ////  //  //  //   ////   //// ////  //  //    ");
            Console.WriteLine("\t  //  // //_//  //   //    //     //  // ///  //    ////    ");
            Console.WriteLine("\t ////   // // ////  ////  //     ////   //// ////  //  //    ");
            Console.WriteLine("\n\n\n\tDecker Ayers || December 2021\n");
            Console.WriteLine("\n\n\t   " + DateTime.Now + "\n\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");



            

        }
        private static int MenuDisplay()
        {
            int selection;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("|\n|\n|\tDailyDeck Menu  - - Current Date/Time: " + DateTime.Now + "\n|\n|");
            Console.WriteLine("|\n|\n|\n|\n|\n|\n|\n|\n|");
            Console.WriteLine("|\n|\t1. View Planner\n|\n|\t2. Enter an Assignment\n|\n|\t3. Remove Assignment\n|\n|\t4. Exit Program\n|\n|\n|\n|\n|\n|\n|");
            Console.ForegroundColor = ConsoleColor.Green ;
            while (true)
            {
                Console.Write("|\tSelection: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                if (int.TryParse(Console.ReadLine(), out int selected) && selected < 5 && selected > 0)
                {
                    selection = selected;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[Invalid Selection -- Try Again]");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            return selection;
        }
        private static void ViewPlanner()

        {
            Console.WriteLine("\n * All Student Records * \n");
            foreach (KeyValuePair<string, Assignment> asn in asnDictionary) // Displays all Students in Dictionary
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{asn.Value}\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            System.Threading.Thread.Sleep(10000);

        }
        private static void EnterAsn()
        {
            bool loopKey = true;
            string asn;
            string course;
            string due;
            do
            {
                Console.WriteLine("\n* Add a New Assignment *");
                do
                {
                    loopKey = true;
                    Console.Write("Assignment Name: ");
                    asn = Console.ReadLine();
                    if (asnDictionary.ContainsKey(asn)) { loopKey = false; }
                    Console.Write("Course: ");
                    course = Console.ReadLine(); // Collects Course
                    if (course == "") { loopKey = false; }
                    Console.Write("Due: ");
                    due = Console.ReadLine(); // Collects Course
                    if (due == "") { loopKey = false; }
                    if (loopKey != false)
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n[Invalid Input for a Field Above -- Try Again]\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                } while (true);

                Assignment assignment = new Assignment(asn, course, due); // New Asn
                asnDictionary.Add(asn, assignment); // Adds New student to Dictionary
                Console.Write("\n\tAdd another assignment?(Y/N): ");
                if (Console.ReadLine().ToUpper() == "Y") { loopKey = false; } // Uses loop condition to add another student

            } while (loopKey == false);
        }

       
        private static void RemoveAsn()
        {
            string select;
            Console.WriteLine("\n * Delete Records * \n");
            foreach (KeyValuePair<string, Assignment> asn in asnDictionary) // Displays all Students in Dictionary
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{asn.Value}\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            do
            {
                Console.Write("Select an Assignment to Remove: ");
                select = Console.ReadLine();
                if (select != "")
                {
                    break;
                }
            } while (true);
            asnDictionary.Remove(select); // Removes from dictionary
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t- - Assignment Removed - -\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}