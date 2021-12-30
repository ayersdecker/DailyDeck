using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace DailyDeck
{
    class Program
    {
        static List<Assignment> asnList = new List<Assignment>();
        static string file = "Planner.Json";
        static void Main(string[] args)
        {
            LoadJson();
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
                        SaveJsonFile();
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
            Console.WriteLine("| Course: N/A\n| Course: N/A\n| Course: N/A\n| Course: N/A\n| Course: N/A\n|\n|\n|\n|");
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
            Console.WriteLine("\n * All Assignments * \n");
            foreach (Assignment asn in asnList) // Displays all Students in Dictionary
            {
                Helper.ColorGreen($"{asn}\n");
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
                    if (asn == "") { loopKey = false; }
                    Console.Write("Course: ");
                    course = Console.ReadLine(); // Collects Course
                    if (course == "") { loopKey = false; }
                    Console.Write("Due: ");
                    due = Console.ReadLine(); // Collects Course
                    if (due == "") { loopKey = false; }
                    if (loopKey != false){ break;}
                    else{ Helper.ColorRed("\n[Invalid Input for a Field Above -- Try Again]\n");}
                } while (true);

                Assignment assignment = new Assignment(asn, course, due); 
                asnList.Add(assignment); 
                Console.Write("\n\tAdd another assignment?(Y/N): ");
                if (Console.ReadLine().ToUpper() == "Y") { loopKey = false; } 

            } while (loopKey == false);
        }
        private static void LoadJson() // Loads current file into program
        {
            {
                if (File.Exists(file))
                {
                    StreamReader reader = new StreamReader(file);
                    string listRead = reader.ReadToEnd();
                    asnList = JsonConvert.DeserializeObject<List<Assignment>>(listRead);
                    reader.Close();
                }
                else { Console.WriteLine("{0} Does not exist", file); }
            }
        }
        private static void SaveJsonFile() // Saves all files into the Json file / Displays count
        {
            string listSerial = JsonConvert.SerializeObject(asnList);
            StreamWriter writer = new StreamWriter(file);
            writer.Write(listSerial);
            writer.Close();

            Console.WriteLine($"\nThere are {asnList.Count} assignment(s) in the list\n");
        }

        private static void RemoveAsn()
        {
            int select;
            int count = 1;
            Dictionary<int, Assignment> asnDic = new Dictionary<int, Assignment>();
            Console.WriteLine("\n * Delete Records * \n");
            foreach (Assignment asn in asnList) // Displays all Students in Dictionary
            {
                asnDic.Add(count, asn);
                Helper.ColorGreen($"{count}. " + asn.ToString());
                count++;
            }
            do
            {
                Console.Write("Select an Assignment to Remove: ");
                select = int.Parse(Console.ReadLine());
                if (select > 0 && select < asnDic.Count)
                {
                    break;
                }
            } while (true);
            Assignment removal = asnDic[select];
            asnList.Remove(removal); // Removes from dictionary
            Helper.ColorGreen("\n\t- - Assignment Removed - -\n");
        }
    }
}