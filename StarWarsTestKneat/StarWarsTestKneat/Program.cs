using StarWarsTestKneat.API;
using StarWarsTestKneat.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsTestKneat
{
    class Program
    {
        /// <summary>
        /// Many things can be improved but for sake of simplicity and time I do not did, 
        /// some technical improvements like dependency injection, system logs and etc.
        /// So I thing in some cases is better to delivery something to the final user 
        /// to get his feedback, before create a complete application full of functionalities, 
        /// that user don't requested, and maybe will never use them.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            ConsoleKeyInfo kinfo;
            do
            {
                Console.WriteLine("Welcome to Star Wars starship converage comparator");
                Console.WriteLine("Please insert the total coverage desired, we will show how many stops each starship have to do to complete the travel.");
                Console.WriteLine("Press Escape (Esc) key to exit \n");
                bool isNumeric = true;

                long totalDistance = 0;
                do
                {
                    kinfo = Console.ReadKey();
                    if (kinfo.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    var typed = kinfo.KeyChar + Console.ReadLine();
                    isNumeric = long.TryParse(typed, out totalDistance);
                    if (!isNumeric)
                    {
                        Console.WriteLine("Please digit only numbers, without any separator or letters.");
                    }

                } while (!isNumeric);


                if (isNumeric && totalDistance > 0)
                {
                    var business = new Orchestration();
                    business.FecthSWServerData(ConfigurationManager.AppSettings["SWBaseApiURI"] + "api/starships", totalDistance);
                    business.AllTasksFinished += Business_AllTasksFinished;
                    Console.Write("Please fecthing data from server...\n");
                    kinfo = Console.ReadKey();
                }



            } while (kinfo.Key != ConsoleKey.Escape);


        }

        private static void Business_AllTasksFinished()
        {
            Console.WriteLine("\n");
            Console.WriteLine("To restart press any key, to exit press Escape(esc)\n");
        }
    }
}
